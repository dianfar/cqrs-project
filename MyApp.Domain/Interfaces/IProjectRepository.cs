using MyApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApp.Domain.Core.Interfaces;

namespace MyApp.Domain.Interfaces
{
    public interface IProjectRepository : IRepository<Project>
    {
        IQueryable<Project> GetProjectsByUser(Guid userId);
    }
}
