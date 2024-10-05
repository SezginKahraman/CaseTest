using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityConfigurations
{
    internal class PickerConfiguration : IEntityTypeConfiguration<Picker>
    {
        public void Configure(EntityTypeBuilder<Picker> builder)
        {
            builder.ToTable("Countries").HasKey(c => c.Id);

            builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
            builder.Property(c => c.CreatedDate).HasColumnName("CreatedDate").IsRequired();
            builder.Property(c => c.UpdatedDate).HasColumnName("UpdatedDate");
            builder.Property(c => c.DeletedDate).HasColumnName("DeletedDate");

            builder.HasQueryFilter(c => !c.DeletedDate.HasValue);

            builder.HasData(getSeeds());
        }

        private IEnumerable<Picker> getSeeds()
        {
            List<Picker> pickers = new();

            Picker picker1 = new()
            {
                Id = 1,
                FirstName = "Samed Berkan",
                LastName = "Ünver",
            };
            Picker picker2 = new()
            {
                Id = 2,
                FirstName = "Sezgin Furkan",
                LastName = "Kahraman",
            };

            pickers.Add(picker1);
            pickers.Add(picker2);

            return pickers;
        }
    }
}
