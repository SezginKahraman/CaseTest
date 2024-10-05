using FluentValidation;

namespace Application.Features.Groups.Commands.CreateGroups
{
    public class CreateGroupsCommandValidator : AbstractValidator<CreateGroupsCommand>
    {
        public CreateGroupsCommandValidator()
        {
            RuleFor(c => c.MatchName).NotEmpty();
        }
    }
}
