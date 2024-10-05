using FluentValidation;

namespace Application.Features.Teams.Commands.Delete;

public class DeleteTeamCommandValidator : AbstractValidator<DeleteTeamCommand>
{
    public DeleteTeamCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}