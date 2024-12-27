using Application.Models.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CopaoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TournamentController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> CreateTournament(CreateTournamentCommand command)
        {
            var result = await _mediator.Send(command);

            return result.IsSuccess
                ? Ok(result.Value)
                : BadRequest(result.Errors);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTournament(int id, UpdateTournamentCommand command)
        {
            command.Id = id;
            var result = await _mediator.Send(command);

            return result.IsSuccess
                ? NoContent()
                : BadRequest(result.Errors);
        }
    }
}
