using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.ToTable("Countries").HasKey(c => c.Id);

        builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
        builder.Property(c => c.Name).HasColumnName("Name");
        builder.Property(c => c.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(c => c.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(c => c.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(c => !c.DeletedDate.HasValue);

        builder.HasData(getSeeds());
    }

    private IEnumerable<Country> getSeeds()
    {
        List<Country> countries = new();

        Country turkey = new()
        {
            Id = 1,
            Name = "Turkiye",
            CountryCode = "TR",
        };
        Country germany = new()
        {
            Id = 2,
            Name = "Almanya",
            CountryCode = "GE",
        };
        Country france = new()
        {
            Id = 3,
            CountryCode = "FR",
            Name = "Fransa",
        };
        Country netherlands = new()
        {
            Id = 4,
            CountryCode = "NL",
            Name = "Hollanda",
        };
        Country portugal = new()
        {
            Id = 5,
            CountryCode = "PR",
            Name = "Portekiz",
        };
        Country italy = new()
        {
            Id = 6,
            CountryCode = "IT",
            Name = "Italya",
        };
        Country spain = new()
        {
            Id = 7,
            CountryCode = "ES",
            Name = "Ispanya",
        };
        Country belgium = new()
        {
            Id = 8,
            CountryCode = "BE",
            Name = "Belcika",
        };
        countries.Add(turkey);
        countries.Add(belgium);
        countries.Add(france);
        countries.Add(netherlands);
        countries.Add(portugal);
        countries.Add(spain);
        countries.Add(germany);
        countries.Add(italy);


        return countries.ToArray();
    }
}