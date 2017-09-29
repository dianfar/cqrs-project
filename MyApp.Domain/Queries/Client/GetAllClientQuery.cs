using MyApp.Domain.Core.Queries;
using System.Linq;
using System.Collections.Generic;
using MyApp.Domain.Models;

namespace MyApp.Domain.Queries
{
    public class GetAllClientQuery : Query<IQueryable<Client>>
    {
        public override bool IsValid()
        {
            return true;
        }
    }
}
