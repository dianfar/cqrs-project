using MyApp.Domain.Interfaces;
using MyApp.Domain.Models;
using MyApp.Infrastructure.Data.Context;

namespace MyApp.Infrastructure.Data.Repository
{
    public class EntryLogRepository : Repository<EntryLog>, IEntryLogRepository
    {
        public EntryLogRepository(MyAppContext context) : base(context)
        {
        }
    }
}
