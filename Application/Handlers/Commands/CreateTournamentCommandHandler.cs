using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Domain.Entities;
using Domain.Common;
using Domain.Interfaces;
using Application.Features.Tournaments.Commands;
using FluentValidation;
using Application.Interfaces;
using Application.Models.Commands;
using Application.Models.Queries;

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
            // Validação
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result<int>.Failure(validationResult.Errors.Select(e => e.ErrorMessage).ToList());

            // Mapeamento e criação
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
                return Result<int>.Failure(new List<string> { "Erro ao criar torneio", ex.Message });
            }
        }
    }

    // Handler para atualizar torneio
    public class UpdateTournamentCommandHandler : IRequestHandler<UpdateTournamentCommand, Result<bool>>
    {
        private readonly ITournamentRepository _repository;
        private readonly IValidator<UpdateTournamentCommand> _validator;

        public UpdateTournamentCommandHandler(
            ITournamentRepository repository,
            IValidator<UpdateTournamentCommand> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<Result<bool>> Handle(UpdateTournamentCommand request, CancellationToken cancellationToken)
        {
            // Validação
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result<bool>.Failure(validationResult.Errors.Select(e => e.ErrorMessage).ToList());

            // Busca o torneio existente
            var tournament = await _repository.GetByIdAsync(request.Id);
            if (tournament == null)
                return Result<bool>.Failure(new List<string> { "Torneio não encontrado" });

            // Atualização
            tournament.Name = request.Name;
            tournament.StartDate = request.StartDate;
            tournament.EndDate = request.EndDate;
            tournament.MaxParticipants = request.MaxParticipants;

            try
            {
                await _repository.Update(tournament);
                return Result<bool>.Success(true);
            }
            catch (Exception ex)
            {
                return Result<bool>.Failure(new List<string> { "Erro ao atualizar torneio", ex.Message });
            }
        }
    }

    // Handler para deletar torneio
    public class DeleteTournamentCommandHandler : IRequestHandler<DeleteTournamentCommand, Result<bool>>
    {
        private readonly ITournamentRepository _repository;

        public DeleteTournamentCommandHandler(ITournamentRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<bool>> Handle(DeleteTournamentCommand request, CancellationToken cancellationToken)
        {
            var tournament = await _repository.GetByIdAsync(request.Id);
            if (tournament == null)
                return Result<bool>.Failure(new List<string> { "Torneio não encontrado" });

            try
            {
                await _repository.Remove(tournament);
                return Result<bool>.Success(true);
            }
            catch (Exception ex)
            {
                return Result<bool>.Failure(new List<string> { "Erro ao remover torneio", ex.Message });
            }
        }
    }

    // Handler para buscar torneio por ID
    public class GetTournamentByIdQueryHandler : IRequestHandler<GetTournamentByIdQuery, Result<Tournament>>
    {
        private readonly ITournamentRepository _repository;

        public GetTournamentByIdQueryHandler(ITournamentRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<Tournament>> Handle(GetTournamentByIdQuery request, CancellationToken cancellationToken)
        {
            var tournament = await _repository.GetByIdAsync(request.Id);

            return tournament != null
                ? Result<Tournament>.Success(tournament)
                : Result<Tournament>.Failure(new List<string> { "Torneio não encontrado" });
        }
    }

    // Handler para listar todos os torneios
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