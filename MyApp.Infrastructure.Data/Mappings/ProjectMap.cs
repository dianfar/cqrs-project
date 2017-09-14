using MyApp.Domain.Models;
using MyApp.Infrastructure.Data.Extensions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MyApp.Infrastructure.Data.Mappings
{
    public class ProjectMap : EntityTypeConfiguration<Project>
    {
        public override void Map(EntityTypeBuilder<Project> builder)
        {
            builder.Property(product => product.Id)
                .HasColumnName("Id");

            builder.Property(product => product.Name)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(product => product.Description)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
