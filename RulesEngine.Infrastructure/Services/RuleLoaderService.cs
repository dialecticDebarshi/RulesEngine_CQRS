using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleEngine.Infrastructure.Services
{
    /*
    public class RuleLoaderService
    {
        private readonly RuleDbContext _context;

        public async Task<List<Workflow>> GetWorkflowsFromDbAsync()
        {
            var dbWorkflows = await _context.Workflows
                .Include(w => w.Rules)
                .Where(w => w.IsActive)
                .ToListAsync();

            // Mapping DB entities to Microsoft.RulesEngine.Models.Workflow
            return dbWorkflows.Select(w => new Workflow
            {
                WorkflowName = w.WorkflowName,
                Rules = w.Rules.Select(r => new Rule
                {
                    RuleName = r.RuleName,
                    SuccessEvent = r.SuccessEvent,
                    ErrorMessage = r.ErrorMessage,
                    Expression = r.Expression,
                    RuleExpressionType = Enum.Parse<RuleExpressionType>(r.ExpressionType)
                }).ToList()
            }).ToList();
        }
    }
    */

    public class RuleLoaderService
    {
        //private readonly ApplicationDbContext _context;

        //public RuleLoaderService(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        //public async Task<List<Workflow>> LoadWorkflowsAsync()
        //{
        //    var workflows = await _context.Workflows
        //        .Where(w => w.IsActive)
        //        .Select(w => new Workflow
        //        {
        //            WorkflowName = w.WorkflowName,
        //            Rules = w.Rules
        //                .Where(r => r.IsActive)
        //                .OrderBy(r => r.Priority)
        //                .Select(r => new Rule
        //                {
        //                    RuleName = r.RuleName,
        //                    Expression = r.Expression,
        //                    RuleExpressionType = Enum.Parse<RuleExpressionType>(r.ExpressionType),
        //                    SuccessEvent = r.SuccessEvent,
        //                    ErrorMessage = r.ErrorMessage
        //                }).ToList()
        //        }).ToListAsync();

        //    return workflows;
        //}
    }
}

/*
 public class RuleLoaderService
{
    private readonly ApplicationDbContext _context;

    public RuleLoaderService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Workflow>> LoadWorkflowsAsync()
    {
        var workflows = await _context.Workflows
            .Where(w => w.IsActive)
            .Select(w => new Workflow
            {
                WorkflowName = w.WorkflowName,
                Rules = w.Rules
                    .Where(r => r.IsActive)
                    .OrderBy(r => r.Priority)
                    .Select(r => new Rule
                    {
                        RuleName = r.RuleName,
                        Expression = r.Expression,
                        RuleExpressionType = Enum.Parse<RuleExpressionType>(r.ExpressionType),
                        SuccessEvent = r.SuccessEvent,
                        ErrorMessage = r.ErrorMessage
                    }).ToList()
            }).ToListAsync();

        return workflows;
    }
}
*/
