using FluentValidation;

namespace Application.Features.Teams.Commands.Create;

public class CreateTeamCommandValidator : AbstractValidator<CreateTeamCommand>
{
    public CreateTeamCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.CountryId).NotEmpty();
    }
}