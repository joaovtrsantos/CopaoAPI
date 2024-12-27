using Application.Models.Commands;
using FluentValidation;

namespace Application.Validators
{
    public class UpdateTournamentCommandValidator : AbstractValidator<UpdateTournamentCommand>
    {
        public UpdateTournamentCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Invalid tournament ID");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Tournament name is required")
                .MinimumLength(3).WithMessage("Name must have at least 3 characters");

            RuleFor(x => x.StartDate)
                .NotEmpty().WithMessage("Start date is required")
                .GreaterThan(DateTime.Now).WithMessage("Start date must be in the future");

            RuleFor(x => x.EndDate)
                .NotEmpty().WithMessage("End date is required")
                .GreaterThan(x => x.StartDate).WithMessage("End date must be after start date");

            RuleFor(x => x.MaxParticipants)
                .GreaterThan(0).WithMessage("Maximum number of participants must be positive");
        }
    }
}
