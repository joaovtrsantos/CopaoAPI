﻿using Application.Common;
using MediatR;

namespace Application.Models.Commands
{
    public class UpdateTournamentCommand : IRequest<Result<bool>>
    {
        public int Id { get; set; }
        public string? Name { get; set; } = string.Empty;
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? MaxParticipants { get; set; }
    }
}
