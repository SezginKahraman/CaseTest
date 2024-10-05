using Core.Persistence.Repositories;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;
public class Draw : Entity<int>
{
    public int Id { get; set; }
    public int TeamId { get; set; }
    public int GroupId { get; set; }
    [ForeignKey(nameof(Picker))]
    public int PickerId { get; set; }
    public string DrawName { get; set; }
    public virtual Picker Picker { get; set; }
    public virtual ICollection<GroupTeam> GroupTeams { get; set; }
}
