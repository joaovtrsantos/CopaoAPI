using MediatR;

namespace Application.Models.Queries
{
    public class GetTournamentByIdQuery : IRequest<Result<bool>>
    {
        public int Id { get; set; }
    }
}
