using MyApp.Domain.Models;
using System;
using System.Linq;
using MyApp.Domain.Core.Interfaces;

namespace MyApp.Domain.Interfaces
{
    public interface IEntryLogRepository : IRepository<EntryLog>
    {
        IQueryable<EntryLog> GetByUser(Guid userId);
    }
}
