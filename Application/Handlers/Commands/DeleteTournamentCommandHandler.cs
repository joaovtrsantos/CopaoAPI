using Application.Common;
using Application.Interfaces;
using Application.Models.Commands;
using MediatR;

namespace Application.Handlers.Commands
{
    public class DeleteTournamentCommandHandler(ITournamentRepository repository) : IRequestHandler<DeleteTournamentCommand, Result<bool>>
    {
        private readonly ITournamentRepository _repository = repository;

        public async Task<Result<bool>> Handle(DeleteTournamentCommand request, CancellationToken cancellationToken)
        {
            var tournament = await _repository.GetByIdAsync(request.Id);
            if (tournament == null)
                return Result<bool>.Failure(["Tournament not found"]);

            try
            {
                await _repository.RemoveAsync(tournament);
                return Result<bool>.Success(true);
            }
            catch (Exception ex)
            {
                return Result<bool>.Failure(["Error removing tournament", ex.Message]);
            }
        }
    }
}
