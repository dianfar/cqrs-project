using MyApp.Domain.Models;
using MyApp.Infrastructure.Data.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MyApp.Infrastructure.Data.Mappings
{
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public override void Map(EntityTypeBuilder<Product> builder)
        {
            builder.Property(product => product.Id)
                .HasColumnName("Id");

            builder.Property(product => product.Name)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(product => product.Quantity)
                .HasColumnType("int")
                .IsRequired();
        }
    }
}
