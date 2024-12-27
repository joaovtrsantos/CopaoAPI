using Application.Common;
using MediatR;

namespace Application.Models.Commands
{
    public class DeleteTournamentCommand : IRequest<Result<bool>>
    {
        public int Id { get; set; }
    }
}
