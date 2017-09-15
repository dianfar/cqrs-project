using MyApp.Domain.Interfaces;
using MyApp.Domain.Models;
using MyApp.Infrastructure.Data.Context;

namespace MyApp.Infrastructure.Data.Repository
{
    public class ProjectMemberRepository : Repository<ProjectMember>, IProjectMemberRepository
    {
        public ProjectMemberRepository(MyAppContext context) : base(context)
        {
        }
    }
}
