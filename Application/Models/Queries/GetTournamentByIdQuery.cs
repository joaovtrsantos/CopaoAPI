using Application.Common;
using Domain.Entities;
using MediatR;

namespace Application.Models.Queries
{
    public class GetTournamentByIdQuery : IRequest<Result<Tournament>>
    {
        public int Id { get; set; }
    }
}
