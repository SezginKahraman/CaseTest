using Application.Features.Pickers.Commands.Create;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Pickers.Commands.Create
{
    public class CreatePickerCommandValidator : AbstractValidator<CreatePickerCommand>
    {
        public CreatePickerCommandValidator()
        {
            RuleFor(c => c.FirstName).NotEmpty();
        }
    }
}
