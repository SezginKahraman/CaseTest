using Application.Features.Countries.Commands.Update;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GroupTeams.Commands.Update
{
    public class UpdateGroupTeamCommandValidator : AbstractValidator<UpdateGroupTeamCommand>
    {
        public UpdateGroupTeamCommandValidator()
        {
            RuleFor(c => c.Id).NotEmpty();
        }
    }
}
