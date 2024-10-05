using FluentValidation;

namespace Application.Features.Teams.Commands.Update;

public class UpdateTeamCommandValidator : AbstractValidator<UpdateTeamCommand>
{
    public UpdateTeamCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.CountryId).NotEmpty();
        RuleFor(c => c.GroupId).NotEmpty();
    }
}