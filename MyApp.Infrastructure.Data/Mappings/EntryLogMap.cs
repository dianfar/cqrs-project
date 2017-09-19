using MyApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyApp.Infrastructure.Data.Extensions;
using System;

namespace MyApp.Infrastructure.Data.Mappings
{
    public class EntryLogMap : EntityTypeConfiguration<EntryLog>
    {
        public override void Map(EntityTypeBuilder<EntryLog> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(c => c.EntryDate)
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(c => c.Hours)
               .HasColumnType("decimal")
               .IsRequired();

            builder.Property(c => c.Description)
               .HasColumnType("varchar(100)")
               .IsRequired();
        }
    }
}
