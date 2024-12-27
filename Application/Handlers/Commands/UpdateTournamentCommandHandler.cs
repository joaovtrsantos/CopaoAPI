using Application.Common;
using Application.Interfaces;
using Application.Models.Commands;
using FluentValidation;
using MediatR;
using Microsoft.IdentityModel.Tokens;

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

            if (request.MaxParticipants.HasValue) tournament.MaxParticipants = request.MaxParticipants.Value;

            if (request.StartDate.HasValue) tournament.StartDate = request.StartDate.Value;

            if (request.EndDate.HasValue) tournament.EndDate = request.EndDate.Value;

            if (request.Name.IsNullOrEmpty()) tournament.Name = request.Name;

            tournament.ChangeDate = DateTime.Now;

            try
            {
                await _repository.UpdateAsync(tournament);
                return Result<bool>.Success(true);
            }
            catch (Exception ex)
            {
                return Result<bool>.Failure(["Error updating tournament", ex.Message]);
            }
        }
    }
}
