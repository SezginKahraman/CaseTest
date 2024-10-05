using Application.Features.Pickers.Commands.Update;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Pickers.Commands.Update
{
    public class UpdatePickerCommandValidator : AbstractValidator<UpdatePickerCommand>
    {
        public UpdatePickerCommandValidator()
        {
            RuleFor(c => c.Id).NotEmpty();
        }
    }
}
