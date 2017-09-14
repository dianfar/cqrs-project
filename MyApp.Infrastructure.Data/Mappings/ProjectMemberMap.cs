using MyApp.Domain.Models;
using MyApp.Infrastructure.Data.Extensions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MyApp.Infrastructure.Data.Mappings
{
    public class ProjectMemberMap : EntityTypeConfiguration<ProjectMember>
    {
        public override void Map(EntityTypeBuilder<ProjectMember> builder)
        {
            builder.Property(product => product.Id)
                .HasColumnName("Id");

            builder.Property(product => product.Project.Id)
                .HasColumnName("ProjectId");

            builder.Property(product => product.User.Id)
                .HasColumnName("UserId");
        }
    }
}
