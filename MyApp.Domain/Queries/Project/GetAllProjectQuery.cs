using MyApp.Domain.Core.Queries;
using MyApp.Domain.Models;
using System;
using System.Linq;

namespace MyApp.Domain.Queries
{
    public class GetAllProjectQuery : Query<IQueryable<Project>>
    {
        public override bool IsValid()
        {
            return true;
        }
    }
}
