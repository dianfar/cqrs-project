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
        private readonly MyAppContext Context;

        public ProjectRepository(MyAppContext context) : base(context)
        {
            this.Context = context;
        }

        public override Project GetById(Guid id)
        {
            return DbSet.Include(p => p.Client)
                .Include(p => p.ProjectMembers)
                .Include("ProjectMembers.User")
                .FirstOrDefault(p => p.Id == id);
        }

        public IQueryable<Project> GetProjectsByUser(Guid userId)
        {
            return from p in this.Context.Project join pm in this.Context.ProjectMember on p.Id equals pm.Project.Id where pm.User.Id == userId select p;
        }
    }
}
