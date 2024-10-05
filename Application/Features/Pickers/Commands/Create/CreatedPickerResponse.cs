using Core.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Pickers.Commands.Create
{
    public class CreatedPickerResponse : IResponse
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; } 

        public string Email { get; set; }
    }
}
