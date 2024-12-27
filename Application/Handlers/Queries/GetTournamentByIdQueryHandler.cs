using Application.Common;
using Application.Interfaces;
using Application.Models.Queries;
using Domain.Entities;
using MediatR;

namespace Application.Handlers.Queries
{
    public class GetTournamentByIdQueryHandler(ITournamentRepository repository) : IRequestHandler<GetTournamentByIdQuery, Result<Tournament>>
    {
        private readonly ITournamentRepository _repository = repository;

        public async Task<Result<Tournament>> Handle(GetTournamentByIdQuery request, CancellationToken cancellationToken)
        {
            var tournament = await _repository.GetByIdAsync(request.Id);

            return tournament != null
                ? Result<Tournament>.Success(tournament)
                : Result<Tournament>.Failure(["Tournament not found"]);
        }
    }
}
