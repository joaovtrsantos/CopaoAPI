using MediatR;

namespace Application.Models.Commands
{
    public class DeleteTournamentCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
