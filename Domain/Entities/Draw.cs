using Core.Persistence.Repositories;

namespace Domain.Entities;
public class Draw : Entity<int>
{
    public Picker Picker { get; set; }
    public int TeamId { get; set; }
    public int GroupId { get; set; }
    public string MatchName { get; set; }
}
