using Application.Features.Countries.Commands.Create;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GroupTeams.Commands.Create
{
    public class CreateGroupTeamCommandValidator : AbstractValidator<CreateGroupTeamCommand>
    {
        public CreateGroupTeamCommandValidator()
        {
            RuleFor(c => c.DrawId).NotEmpty();
            RuleFor(c => c.TeamId).NotEmpty();
            RuleFor(c => c.TeamId).NotEmpty();
        }
    }
}
