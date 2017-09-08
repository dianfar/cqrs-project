using Microsoft.EntityFrameworkCore;
using MyApp.Domain.Interfaces;
using MyApp.Domain.Models;
using MyApp.Infrastructure.Data.Context;
using System;
using System.Linq;

namespace MyApp.Infrastructure.Data.Repository
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        public ProjectRepository(MyAppContext context) : base(context)
        {
        }

        public override Project GetById(Guid id)
        {
            return DbSet.Include(p => p.Client).FirstOrDefault(p => p.Id == id);
        }
    }
}
