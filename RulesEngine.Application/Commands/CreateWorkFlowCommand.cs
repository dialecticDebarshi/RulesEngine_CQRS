//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace RuleEngine.Application.Commands
//{
//    internal class CreateWorkFlowCommand
//    {
//    }
//}
using MediatR;
using RuleEngine.Contract;
using RuleEngine.Domain.Entities;
//using RuleEngine.Infrastructure.Data;

public record CreateWorkflowCommand(Workflow Workflow):IRequest<Workflow>;// (string Name, List<RuleEntity> Rules) : IRequest<int>;

public class CreateWorkflowHandler(IWorkFlows workFlows) : IRequestHandler<CreateWorkflowCommand, Workflow>
{
  //  private readonly RuleDbContext _context;
  //  public CreateWorkflowHandler(RuleDbContext context) => _context = context;

    public async Task<Workflow> Handle(CreateWorkflowCommand request, CancellationToken ct)
    {
        return await workFlows.AddWorkflowAsync(request.Workflow);
        //var workflow = new Workflow { WorkflowName = request.Name, Rules = request.Rules };
        //_context.Workflows.Add(workflow);
        //await _context.SaveChangesAsync(ct);
        //return workflow.Id;
    }
}
