using Core.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Teams.Commands.CleanTeamsGroups
{
    public class CleanTeamsGroupsResponse : IResponse
    {
        public string Response {  get; set; }
    }
}
