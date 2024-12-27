using Application.Common;
using Application.Interfaces;
using Application.Models.Queries;
using Domain.Entities;
using MediatR;

namespace Application.Handlers.Queries
{
    public class GetAllTournamentsQueryHandler : IRequestHandler<GetAllTournamentsQuery, Result<IEnumerable<Tournament>>>
    {
        private readonly ITournamentRepository _repository;

        public GetAllTournamentsQueryHandler(ITournamentRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<IEnumerable<Tournament>>> Handle(GetAllTournamentsQuery request, CancellationToken cancellationToken)
        {
            var tournaments = await _repository.GetAllAsync();
            return Result<IEnumerable<Tournament>>.Success(tournaments);
        }
    }
}
