using System.IO;
using MyApp.Infrastructure.Data.Mappings;
using MyApp.Infrastructure.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyApp.Domain.Models;

namespace MyApp.Infrastructure.Data.Context
{
    public class MyAppContext : DbContext
    {
        public DbSet<Project> Project { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new ClientMap());
            modelBuilder.AddConfiguration(new ProjectMap());
            modelBuilder.AddConfiguration(new UserMap());
            modelBuilder.AddConfiguration(new RoleMap());
            modelBuilder.AddConfiguration(new ProjectMemberMap());

            modelBuilder.Entity<Project>().HasOne(project => project.Client);
            modelBuilder.Entity<Project>().HasMany(project => project.ProjectMembers).WithOne(member => member.Project);
            modelBuilder.Entity<User>().HasOne(user => user.Role);
            modelBuilder.Entity<ProjectMember>().HasOne(member => member.User);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }
    }
}
