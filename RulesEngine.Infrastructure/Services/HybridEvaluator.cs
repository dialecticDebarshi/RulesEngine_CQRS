using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace RuleEngine.Infrastructure.Services
//{
//    internal class HybridEvaluator
//    {
//    }
//}
//using Microsoft.RulesEngine;
//using Polly;

//public class HybridEvaluator : IHybridEvaluator
//{
//    private readonly RuleDbContext _db;
//    private readonly IAsyncPolicy _retryPolicy;

//    public HybridEvaluator(RuleDbContext db)
//    {
//        _db = db;
//        // Exponential backoff for Logic App (Max 5 mins total)
//        _retryPolicy = Policy.Handle<Exception>()
//            .WaitAndRetryAsync(5, retry => TimeSpan.FromSeconds(Math.Pow(2, retry)));
//    }

//    public async Task<RuleResponse> EvaluateAsync(HealthcareClaim claim)
//    {
//        var workflows = await LoadWorkflowsAsync();
//        var bre = new RulesEngine.RulesEngine(workflows.ToArray());

//        // Local Execution
//        var results = await bre.ExecuteAllRulesAsync("USHealthcareRules", claim);

//        foreach (var res in results)
//        {
//            if (!res.IsSuccess)
//            {
//                // Check if this specific rule needs the Logic App Hybrid Bridge
//                if (res.Rule.RuleExpressionType == RuleExpressionType.LambdaExpression)
//                    return new RuleResponse(false, res.ExceptionMessage, "Rejected");

//                // If Rule marked for Logic App
//                return await _retryPolicy.ExecuteAsync(() => CallLogicAppBridge(claim));
//            }
//        }
//        return new RuleResponse(true, "All Rules Passed", "Approved");
//    }

//    private async Task<RuleResponse> CallLogicAppBridge(HealthcareClaim claim)
//    {
//        // Mocking Logic App HTTP Call
//        await Task.Delay(100);
//        return new RuleResponse(true, "Logic App Approved", "Approved");
//    }

//    private async Task<List<Workflow>> LoadWorkflowsAsync()
//    {
//        return await _db.Workflows.Include(x => x.Rules)
//            .Select(w => new Workflow
//            {
//                WorkflowName = w.WorkflowName,
//                Rules = w.Rules.Select(r => new Rule
//                {
//                    RuleName = r.RuleName,
//                    Expression = r.Expression,
//                    SuccessEvent = r.SuccessEvent
//                }).ToList()
//            }).ToListAsync();
//    }
//}