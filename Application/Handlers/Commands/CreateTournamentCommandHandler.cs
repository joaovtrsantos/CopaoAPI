using MediatR;
using Domain.Entities;
using FluentValidation;
using Application.Interfaces;
using Application.Models.Commands;
using Application.Common;

namespace Application.Features.Tournaments.Handlers
{
    // Handler para criar torneio
    public class CreateTournamentCommandHandler(
        ITournamentRepository repository,
        IValidator<CreateTournamentCommand> validator) : IRequestHandler<CreateTournamentCommand, Result<int>>
    {
        private readonly ITournamentRepository _repository = repository;
        private readonly IValidator<CreateTournamentCommand> _validator = validator;

        public async Task<Result<int>> Handle(CreateTournamentCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result<int>.Failure(validationResult.Errors.Select(e => e.ErrorMessage).ToList());

            var tournament = new Tournament
            {
                Name = request.Name,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                MaxParticipants = request.MaxParticipants
            };

            try
            {
                var createdTournament = await _repository.AddAsync(tournament);
                return Result<int>.Success(createdTournament.Id);
            }
            catch (Exception ex)
            {
                return Result<int>.Failure(new List<string> { "Error creating tournament", ex.Message });
            }
        }
    }
}