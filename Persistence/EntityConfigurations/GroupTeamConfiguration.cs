using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityConfigurations
{
    public class GroupTeamConfiguration : IEntityTypeConfiguration<GroupTeam>
    {

        public void Configure(EntityTypeBuilder<GroupTeam> builder)
        {

            builder.ToTable("GroupTeams").HasKey(c => c.Id);

            builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
            builder.HasOne(t => t.Group).WithMany(t => t.GroupTeams);
            builder.HasOne(t => t.Team).WithMany(t => t.GroupTeams);
            builder.HasOne(t => t.Draw).WithMany(t => t.GroupTeams);

            builder.Property(c => c.CreatedDate).HasColumnName("CreatedDate").IsRequired();
            builder.Property(c => c.UpdatedDate).HasColumnName("UpdatedDate");
            builder.Property(c => c.DeletedDate).HasColumnName("DeletedDate");

            builder.HasQueryFilter(c => !c.DeletedDate.HasValue);
        }
    }
}
