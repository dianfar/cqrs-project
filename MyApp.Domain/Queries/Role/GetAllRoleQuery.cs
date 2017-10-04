using MyApp.Domain.Core.Queries;
using MyApp.Domain.Models;
using System.Linq;

namespace MyApp.Domain.Queries
{
    public class GetAllRoleQuery : Query<IQueryable<Role>>
    {
        public override bool IsValid()
        {
            return true;
        }
    }
}
