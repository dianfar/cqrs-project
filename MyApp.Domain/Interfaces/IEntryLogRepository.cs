using MyApp.Domain.Models;
using System;
using System.Linq;

namespace MyApp.Domain.Interfaces
{
    public interface IEntryLogRepository : IRepository<EntryLog>
    {
        IQueryable<EntryLog> GetByUser(Guid userId);
    }
}
