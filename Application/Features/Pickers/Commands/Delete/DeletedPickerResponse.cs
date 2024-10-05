using Core.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Pickers.Commands.Delete
{
    public class DeletedPickerResponse : IResponse
    {
        public int Id { get; set; }
    }
}
