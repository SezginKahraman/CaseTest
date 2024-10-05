using FluentValidation;

namespace Application.Features.Draws.Commands.Delete;

public class DeleteDrawCommandValidator : AbstractValidator<DeleteDrawCommand>
{
    public DeleteDrawCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}