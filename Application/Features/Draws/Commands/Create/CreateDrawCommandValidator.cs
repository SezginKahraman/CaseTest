using FluentValidation;

namespace Application.Features.Draws.Commands.Create;

public class CreateDrawCommandValidator : AbstractValidator<CreateDrawCommand>
{
    public CreateDrawCommandValidator()
    {
        RuleFor(c => c.Picker).NotEmpty();
        RuleFor(c => c.TeamId).NotEmpty();
        RuleFor(c => c.GroupId).NotEmpty();
    }
}