using MyApp.Domain.Core.Queries;
using MyApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyApp.Domain.Queries
{
    public class GetAllUserQuery : Query<IQueryable<User>>
    {
        public override bool IsValid()
        {
            return true;
        }
    }
}
