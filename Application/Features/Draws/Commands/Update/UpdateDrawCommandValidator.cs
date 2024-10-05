using FluentValidation;

namespace Application.Features.Draws.Commands.Update;

public class UpdateDrawCommandValidator : AbstractValidator<UpdateDrawCommand>
{
    public UpdateDrawCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Picker).NotEmpty();
        RuleFor(c => c.TeamId).NotEmpty();
        RuleFor(c => c.GroupId).NotEmpty();
    }
}