//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace RuleEngine.Application.Commands.Features
//{
//    internal class ProcessClaimCommand
//    {
//    }
//}
using MediatR;
//using RuleEngine.Contract;
//using RuleEngine.Domain.Common;
//using RuleEngine.Domain.Entities;

//public record ProcessClaimCommand(HealthcareClaim Claim) : IRequest<RuleResponse>;

//public class ProcessClaimHandler : IRequestHandler<ProcessClaimCommand, RuleResponse>
//{
//    private readonly IHybridEvaluator _evaluator;
//    private readonly IMediator _mediator;

//    public ProcessClaimHandler(IHybridEvaluator evaluator, IMediator mediator)
//    {
//        _evaluator = evaluator;
//        _mediator = mediator;
//    }

//    public async Task<RuleResponse> Handle(ProcessClaimCommand request, CancellationToken ct)
//    {
//        // 1. Execute Hybrid Evaluation (Local + Logic App Retry)
//        var result = await _evaluator.EvaluateAsync(request.Claim);

//        // 2. Event-Driven Audit (Non-blocking)
//    //    await _mediator.Publish(new ClaimProcessedEvent(request.Claim.ClaimId, result.Status), ct);

//        return result;
//    }
//}