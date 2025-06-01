using LeadManagement.Application.Commands;
using LeadManagement.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LeadManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeadsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeadsController(IMediator mediator) => _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> Create(CreateLeadCommand command) =>
            Ok(await _mediator.Send(command));

        [HttpPost("{id}/accept")]
        public async Task<IActionResult> Accept(int id) =>
            Ok(await _mediator.Send(new AcceptLeadCommand(id)));

        [HttpPost("{id}/decline")]
        public async Task<IActionResult> Decline(int id) =>
            Ok(await _mediator.Send(new DeclineLeadCommand(id)));

        [HttpGet("invited")]
        public async Task<IActionResult> Invited() =>
            Ok(await _mediator.Send(new GetInvitedLeadsQuery()));

        [HttpGet("accepted")]
        public async Task<IActionResult> Accepted() =>
            Ok(await _mediator.Send(new GetAcceptedLeadsQuery()));
    }
}
