using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class GroupTeam : Entity<int>
    {
        public int Id { get; set; }
        [ForeignKey(nameof(Group))]
        public int GroupId { get; set; }    
        [ForeignKey(nameof(Team))]
        public int TeamId { get; set; }
        [ForeignKey(nameof(Draw))]
        public int DrawId { get; set; }
        public Group Group { get; set; }
        public Team Team { get; set; }
        public Draw Draw { get; set; }
    }
}
