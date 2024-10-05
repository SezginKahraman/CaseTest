using Application.Features.Countries.Commands.Delete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GroupTeams.Commands.Delete
{
    public class DeleteGroupTeamCommandValidator : AbstractValidator<DeleteGroupTeamCommand>
    {
        public DeleteGroupTeamCommandValidator()
        {
            RuleFor(c => c.Id).NotEmpty();
        }
    }
}
