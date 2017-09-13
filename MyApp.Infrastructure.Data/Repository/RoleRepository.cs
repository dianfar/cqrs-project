using MyApp.Domain.Interfaces;
using MyApp.Domain.Models;
using MyApp.Infrastructure.Data.Context;

namespace MyApp.Infrastructure.Data.Repository
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(MyAppContext context) : base(context)
        {
        }
    }
}
