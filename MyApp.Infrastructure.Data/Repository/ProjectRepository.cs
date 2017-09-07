using MyApp.Domain.Interfaces;
using MyApp.Domain.Models;
using MyApp.Infrastructure.Data.Context;

namespace MyApp.Infrastructure.Data.Repository
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        public ProjectRepository(MyAppContext context) : base(context)
        {
        }
    }
}
