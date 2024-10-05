using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class TeamConfiguration : IEntityTypeConfiguration<Team>
{
    public void Configure(EntityTypeBuilder<Team> builder)
    {
        builder.ToTable("Teams").HasKey(t => t.Id);

        builder.Property(t => t.Id).HasColumnName("Id").IsRequired();
        builder.Property(t => t.Name).HasColumnName("Name");
        builder.Property(t => t.CountryId).HasColumnName("CountryId");
        builder.Property(t => t.GroupId).HasColumnName("GroupId");
        builder.Property(t => t.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(t => t.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(t => t.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(t => !t.DeletedDate.HasValue);

        builder.HasData(getSeeds());
    }

    private IEnumerable<Team> getSeeds()
    {
        List<Team> teams = new();

        Team adessoIstanbul = new()
        {
            CountryId = 1,
            GroupId = null,
            Name = "Adesso Istanbul",
        };
        Team adessoAnkara = new()
        {
            CountryId = 1,
            GroupId = null,
            Name = "Adesso Ankara",
        };
        Team adessoIzmir = new()
        {
            CountryId = 1,
            GroupId = null,
            Name = "Adesso Izmir",
        };
        Team adessoAntalya = new()
        {
            CountryId = 1,
            GroupId = null,
            Name = "Adesso Antalya",
        };

        Team adessoBerlin = new()
        {
            CountryId = 2,
            GroupId = null,
            Name = "Adesso Berlin",
        };
        Team adessoFrankfurt = new()
        {
            CountryId = 2,
            GroupId = null,
            Name = "Adesso Frankfurt",
        };
        Team adessoMunih = new()
        {
            CountryId = 2,
            GroupId = null,
            Name = "Adesso Munih",
        };
        Team adessoDortmund = new()
        {
            CountryId = 2,
            GroupId = null,
            Name = "Adesso Dortmund",
        };

        Team adessoParis = new()
        {
            CountryId = 3,
            GroupId = null,
            Name = "Adesso Paris",
        };
        Team adessoMarsilya = new()
        {
            CountryId = 3,
            GroupId = null,
            Name = "Adesso Marsilya",
        };
        Team adessoNice = new()
        {
            CountryId = 3,
            GroupId = null,
            Name = "Adesso Nice",
        };
        Team adessoLyon = new()
        {
            CountryId = 3,
            GroupId = null,
            Name = "Adesso Lyon",
        };

        Team adessoAmsterdam = new()
        {
            CountryId = 4,
            GroupId = null,
            Name = "Adesso Amsterdam",
        };
        Team adessoRotterdam = new()
        {
            CountryId = 4,
            GroupId = null,
            Name = "Adesso Rotterdam",
        };
        Team adessoLahey = new()
        {
            CountryId = 4,
            GroupId = null,
            Name = "Adesso Lahey",
        };
        Team adessoEindhoven = new()
        {
            CountryId = 4,
            GroupId = null,
            Name = "Adesso Eindhoven",
        };

        Team adessoLisbon = new()
        {
            CountryId = 5,
            GroupId = null,
            Name = "Adesso Lisbon",
        };
        Team adessoPorto = new()
        {
            CountryId = 5,
            GroupId = null,
            Name = "Adesso Porto",
        };
        Team adessoBraga = new()
        {
            CountryId = 5,
            GroupId = null,
            Name = "Adesso Braga",
        };
        Team adessoCoimbra = new()
        {
            CountryId = 5,
            GroupId = null,
            Name = "Adesso Coimbra",
        };

        Team adessoRoma = new()
        {
            CountryId = 6,
            GroupId = null,
            Name = "Adesso Roma",
        };
        Team adessoMilano = new()
        {
            CountryId = 6,
            GroupId = null,
            Name = "Adesso Milano",
        };
        Team adessoVenedik = new()
        {
            CountryId = 6,
            GroupId = null,
            Name = "Adesso Venedik",
        };
        Team adessoNapoli = new()
        {
            CountryId = 6,
            GroupId = null,
            Name = "Adesso Napoli",
        };

        Team adessoSevilla = new()
        {
            CountryId = 7,
            GroupId = null,
            Name = "Adesso Sevilla",
        };
        Team adessoMadrid = new()
        {
            CountryId = 7,
            GroupId = null,
            Name = "Adesso Madrid",
        };
        Team adessoBarselona = new()
        {
            CountryId = 7,
            GroupId = null,
            Name = "Adesso Barselona",
        };
        Team adessoGranada = new()
        {
            CountryId = 7,
            GroupId = null,
            Name = "Adesso Granada",
        };

        Team adessoBruksel = new()
        {
            CountryId = 8,
            GroupId = null,
            Name = "Adesso Bruksel",
        };
        Team adessoBrugge = new()
        {
            CountryId = 8,
            GroupId = null,
            Name = "Adesso Brugge",
        };
        Team adessoGent = new()
        {
            CountryId = 8,
            GroupId = null,
            Name = "Adesso Gent",
        };
        Team adessoAnvers = new()
        {
            CountryId = 8,
            GroupId = null,
            Name = "Adesso Anvers",
        };

        teams.Add(adessoIstanbul);
        teams.Add(adessoAntalya);
        teams.Add(adessoIzmir);
        teams.Add(adessoAnkara);

        teams.Add(adessoBerlin);
        teams.Add(adessoDortmund);
        teams.Add(adessoMunih);
        teams.Add(adessoFrankfurt);
        
        teams.Add(adessoParis);
        teams.Add(adessoLyon);
        teams.Add(adessoMarsilya);
        teams.Add(adessoNice);

        teams.Add(adessoEindhoven);
        teams.Add(adessoAmsterdam);
        teams.Add(adessoLahey);
        teams.Add(adessoRotterdam);

        teams.Add(adessoLisbon);
        teams.Add(adessoPorto);
        teams.Add(adessoBraga);
        teams.Add(adessoCoimbra);

        teams.Add(adessoRoma);
        teams.Add(adessoMilano);
        teams.Add(adessoVenedik);
        teams.Add(adessoNapoli);

        teams.Add(adessoSevilla);
        teams.Add(adessoMadrid);
        teams.Add(adessoBarselona);
        teams.Add(adessoGranada);

        teams.Add(adessoBruksel);
        teams.Add(adessoBrugge);
        teams.Add(adessoGent);
        teams.Add(adessoAnvers);



        return teams.ToArray();
    }

    }