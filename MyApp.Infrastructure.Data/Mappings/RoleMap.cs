using MyApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyApp.Infrastructure.Data.Extensions;

namespace MyApp.Infrastructure.Data.Mappings
{
    public class RoleMap : EntityTypeConfiguration<Role>
    {
        public override void Map(EntityTypeBuilder<Role> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(c => c.Name)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
