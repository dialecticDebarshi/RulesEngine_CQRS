using RuleEngine.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleEngine.Contract
{
        public interface IWorkFlows
        {
            public Task<IEnumerable<Workflow>> GetWorkflows();

            public Task<Workflow> GetWorkflowById(Guid id);

            public Task<Workflow> AddWorkflowAsync(Workflow workflow);
            public Task<Workflow> EditWorkflowAsync(Workflow workflow, Guid id);
            public Task<bool> RemoveWorkflowAsync(Guid id);
            public Task<Workflow?> GetWorkflowByNameAsync(string workflowName);


        }
    }
