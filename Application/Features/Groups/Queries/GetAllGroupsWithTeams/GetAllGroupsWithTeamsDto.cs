using Domain.Entities;

namespace Application.Features.Groups.Queries.GetAllGroupsWithTeams
{
    public class GetAllGroupsWithTeamsDto
    {
        public string Name { get; set; }
        public IList<string> Teams { get; set; }
    }
}
