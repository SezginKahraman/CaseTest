using FluentValidation;

namespace Application.Features.Draws.Commands.Create;

public class CreateDrawCommandValidator : AbstractValidator<CreateDrawCommand>
{
    public CreateDrawCommandValidator()
    {
    }
}