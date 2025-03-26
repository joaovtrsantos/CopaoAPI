using Application.Interfaces;
using Application.Models.Commands;
using Domain.Entities;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Application.Features.Tournaments.Handlers
{
    // Handler para criar torneio
    public class CreateTournamentCommandHandler(
        ITournamentRepository repository,
        IValidator<CreateTournamentCommand> validator,
        ILogger<CreateTournamentCommandHandler> logger) : IRequestHandler<CreateTournamentCommand, bool>
    {
        private readonly ITournamentRepository _repository = repository;
        private readonly IValidator<CreateTournamentCommand> _validator = validator;
        private readonly ILogger<CreateTournamentCommandHandler> _logger = logger;

        public async Task<bool> Handle(CreateTournamentCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(@"[CreateTournamentCommandHandler] Tournament creation started {request}", new
            {
                request = JsonSerializer.Serialize(request)
            });

            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            //TODO: STARTS HERE, TO START NEW LOGS FOR VALIDATION.
            if (!validationResult.IsValid)
                return false;
                //TODO: To test the return if doesnt validate

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
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}