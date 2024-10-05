using Core.Persistence.Repositories;

namespace Domain.Entities;
public class Group : Entity<int>
{
    public string Name { get; set; }
    public virtual ICollection<Team> Teams { get; set; }
    public virtual ICollection<GroupTeam> GroupTeams { get; set; }
    public Group()
    {
    }

    public Group(int id, string matchName, string name)
    {
        Id = id;
        Name = name;
    }   
}
