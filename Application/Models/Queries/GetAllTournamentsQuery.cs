using Application.Common;
using Domain.Entities;
using MediatR;

namespace Application.Models.Queries
{
    public class GetAllTournamentsQuery : IRequest<Result<IEnumerable<Tournament>>>
    {
    }
}
