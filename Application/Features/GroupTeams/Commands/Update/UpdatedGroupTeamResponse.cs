using Core.Application.Responses;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GroupTeams.Commands.Update
{
    public class UpdatedGroupTeamResponse : IResponse
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public int TeamId { get; set; }
        public int DrawId { get; set; }
    }
}
