using MediatR;
using RuleEngine.Contract;
using RuleEngine.Domain.Entities;
using RuleEngine.Domain.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleEngine.Application.Queries
{
    //using global::RuleEngine.Domain.Entities;
    //using MediatR;

    //namespace RuleEngine.Application.Workflows.Queries;

    public record EvaluateClaimQuery(string WorkflowName, HealthcareClaim Claim) : IRequest<RuleEvaluationResult>;

    public class EvaluateClaimHandler(IWorkFlows repository) : IRequestHandler<EvaluateClaimQuery, RuleEvaluationResult>
    {
        public async Task<RuleEvaluationResult> Handle(EvaluateClaimQuery request, CancellationToken ct)
        {
            // 1. Fetch the Workflow from MSSQL
            var dbWorkflow = await repository.GetWorkflowByNameAsync(request.WorkflowName);

            if (dbWorkflow == null)
            {
                return new RuleEvaluationResult { IsSuccess = false, Status = "Error", Messages = new() { "Workflow not found." } };
            }

            // 2. Map RuleEntity to Microsoft.RulesEngine.Models.Rule
            var workflowSettings = new RulesEngine.Models.Workflow
            {
                WorkflowName = dbWorkflow.WorkflowName,
                Rules = dbWorkflow.Rules.OrderBy(r => r.Priority).Select(r => new RulesEngine.Models.Rule
                {
                    RuleName = r.RuleName,
                    SuccessEvent = r.SuccessEvent,
                    ErrorMessage = r.ErrorMessage,
                    Expression = r.Expression,
                    RuleExpressionType = RulesEngine.Models.RuleExpressionType.LambdaExpression
                }).ToList()
            };

            // 3. Initialize and Execute the Engine
            var engine = new RulesEngine.RulesEngine(new[] { workflowSettings });

            // input1 is the default name used in expressions like "input1.Age > 18"
            var results = await engine.ExecuteAllRulesAsync(dbWorkflow.WorkflowName, request.Claim);

            // 4. Consolidate Results
            var response = new RuleEvaluationResult
            {
                IsSuccess = results.All(r => r.IsSuccess),
                Status = results.All(r => r.IsSuccess) ? "Approved" : "Rejected",
                Messages = results.Where(r => !r.IsSuccess)
                                  .Select(r => r.ExceptionMessage ?? r.Rule.ErrorMessage)
                                  .ToList()
            };

            return response;
        }
    }
}
