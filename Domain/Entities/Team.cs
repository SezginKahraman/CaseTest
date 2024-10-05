using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class Team : Entity<int>
    {
        public string Name { get; set; }
        public int CountryId { get; set; }
        public int? GroupId { get; set; }
        public virtual Group Group { get; set; }
        public virtual Country Country{ get; set; }
        public virtual ICollection<GroupTeam> GroupTeams { get; set; }

        public Team()
        {
        }

        public Team(int id,string name, int countryId, int groupId)
        {
            Id = id;
            Name = name;
            CountryId = countryId;
            GroupId = groupId;
 
        }
    }
}
