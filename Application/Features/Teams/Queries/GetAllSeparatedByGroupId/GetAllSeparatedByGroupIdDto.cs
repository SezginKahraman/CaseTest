using Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Teams.Queries.GetAllSeparatedByGroupId
{
    public class GetAllSeparatedByGroupIdDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CountryName { get; set; }
        public string GroupName { get; set; }
    }
}
