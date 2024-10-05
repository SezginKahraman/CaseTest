using Application.Features.Pickers.Commands.Delete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Pickers.Commands.Delete
{
    public class DeletePickerCommandValidator : AbstractValidator<DeletePickerCommand>
    {
        public DeletePickerCommandValidator()
        {
            RuleFor(c => c.Id).NotEmpty();
        }
    }
}
