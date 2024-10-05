using Core.Persistence.Repositories;

namespace Domain.Entities;
public class Country : Entity<int>
{
    public Country()
    {
    }
    public Country(int id, string name)
    {
        Id = id;
        Name = name;
    }
    public string Name { get; set; }

    public string CountryCode { get; set; }
   
}
