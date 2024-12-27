using Application.Common;
using Application.Interfaces;
using Application.Models.Commands;
using FluentValidation;
using MediatR;

namespace Application.Handlers.Commands
{
    public class UpdateTournamentCommandHandler(
        ITournamentRepository repository,
        IValidator<UpdateTournamentCommand> validator) : IRequestHandler<UpdateTournamentCommand, Result<bool>>
    {
        private readonly ITournamentRepository _repository = repository;
        private readonly IValidator<UpdateTournamentCommand> _validator = validator;

        public async Task<Result<bool>> Handle(UpdateTournamentCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result<bool>.Failure(validationResult.Errors.Select(e => e.ErrorMessage).ToList());

            var tournament = await _repository.GetByIdAsync(request.Id);
            if (tournament == null)
                return Result<bool>.Failure(["Tournament not found"]);

            tournament.Name = request.Name;
            tournament.StartDate = request.StartDate;
            tournament.EndDate = request.EndDate;
            tournament.MaxParticipants = request.MaxParticipants;

            try
            {
                await _repository.UpdateAsync(tournament);
                return Result<bool>.Success(true);
            }
            catch (Exception ex)
            {
                return Result<bool>.Failure(new List<string> { "Error updating tournament", ex.Message });
            }
        }
    }
}
