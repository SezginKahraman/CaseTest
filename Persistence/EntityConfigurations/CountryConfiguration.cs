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
            Id = int.Parse("d2bc1850-e738-49a2-b262-08dbe128c8cd"),
            Name = "Turkiye",
        };
        Country germany = new()
        {
            Id = int.Parse("d3749aac-ed3e-442e-8206-d508b1b94dcc"),
            Name = "Almanya",
        };
        Country france = new()
        {
            Id = int.Parse("2fafbee5-f65d-48a5-8637-270a9ae5cd4c"),
            Name = "Fransa",
        };
        Country netherlands = new()
        {
            Id = int.Parse("34a9d6f9-26aa-4cc6-96fc-7cf6f46e13eb"),
            Name = "Hollanda",
        };
        Country portugal = new()
        {
            Id = int.Parse("f5f76ad1-25ba-452c-90c0-2c1f33df58db"),
            Name = "Portekiz",
        };
        Country italy = new()
        {
            Id = int.Parse("35cd46ac-8347-48c1-8e5b-c631eb655d79"),
            Name = "Italya",
        };
        Country spain = new()
        {
            Id = int.Parse("a7170631-6b14-4e7e-b2a9-22bb1403ab8a"),
            Name = "Ispanya",
        };
        Country belgium = new()
        {
            Id = int.Parse("4067b3e2-d378-46a4-a25b-cc5be4c24472"),
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