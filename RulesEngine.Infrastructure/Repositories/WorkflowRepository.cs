using RuleEngine.Domain.Entities;
using RuleEngine.Contract;
using RuleEngine.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using RuleEngine.Contract;
using RuleEngine.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleEngine.Infrastructure.Repositories
{
    public class WorkflowRepository(RuleDbContext dbContext) : IWorkFlows
    {
        public async Task<IEnumerable<Workflow>> GetWorkflows()
        {
            return await dbContext.Workflows.ToListAsync();
        }

        public async Task<Workflow> GetWorkflowById(Guid id)
        {
            return await dbContext.Workflows.FirstOrDefaultAsync(e => e.Id == id);
        }
        public async Task<Workflow> AddWorkflowAsync(Workflow workflow)
        {
            workflow.Id= Guid.NewGuid();
            dbContext.AddAsync(workflow);
            await dbContext.SaveChangesAsync();
            return workflow;

        }
        public async Task<Workflow> EditWorkflowAsync(Workflow workflow, Guid id)
        {
            var workFlow= await dbContext.Workflows.FirstOrDefaultAsync(w => w.Id == id);
            if (workFlow != null)
            {
                // empl.Id = id;
                workFlow.WorkflowName = workflow.WorkflowName;
                workFlow.Rules = workflow.Rules;
                workFlow.IsActive = workflow.IsActive;
               

                dbContext.Update(workFlow);
                await dbContext.SaveChangesAsync();

            }
            return workFlow;

        }

        public async Task<bool> RemoveWorkflowAsync(Guid id)
        {
            var workFlow = await dbContext.Workflows.FirstOrDefaultAsync(w => w.Id == id);
            if (workFlow != null)
            {
                 dbContext.Workflows.Remove(workFlow);
                return await dbContext.SaveChangesAsync()>0;

            }
            return false;

        }

        public async Task<Workflow?> GetWorkflowByNameAsync(string workflowName)
        {
            return await dbContext.Workflows
                .Include(w => w.Rules)
                .FirstOrDefaultAsync(w => w.WorkflowName == workflowName && w.IsActive);
        }
    }
}
