using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RuleEngine.Application.Queries;
using RuleEngine.Domain.Entities;
using RuleEngine.Domain.Models.Responses;

namespace RulesEngine.Plugins.Claims.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class WorkflowsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WorkflowsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Saves a new workflow along with its rules to the MSSQL database.
        /// </summary>
        /// <param name="workflow">The workflow entity including its rules.</param>
        /// <returns>The created workflow with its generated Guid.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Workflow>> Create([FromBody] Workflow workflow)
        {
            if (workflow == null)
            {
                return BadRequest("Workflow data is required.");
            }

            try
            {
                // Send the command through MediatR to the CreateWorkflowHandler
                var result = await _mediator.Send(new CreateWorkflowCommand(workflow));

                // Return 201 Created with the saved entity
                return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
            }
            catch (Exception ex)
            {
                // Log exception here (e.g., via Serilog or Azure Monitor)
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Workflow>> GetById(Guid id)
        {
            // This would call your GetWorkflowById query/repository
            // Implementation provided to satisfy CreatedAtAction requirement
            return Ok();
        }

        [HttpPost("evaluate/{workflowName}")]
        public async Task<ActionResult<RuleEvaluationResult>> Evaluate(string workflowName, [FromBody] HealthcareClaim claim)
        {
            if (claim == null) return BadRequest("Claim data is required.");

            var result = await _mediator.Send(new EvaluateClaimQuery(workflowName, claim));

            return Ok(result);
        }

    }
}
