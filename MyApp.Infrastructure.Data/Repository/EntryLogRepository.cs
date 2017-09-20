using Microsoft.EntityFrameworkCore;
using MyApp.Domain.Interfaces;
using MyApp.Domain.Models;
using MyApp.Infrastructure.Data.Context;
using System;
using System.Linq;

namespace MyApp.Infrastructure.Data.Repository
{
    public class EntryLogRepository : Repository<EntryLog>, IEntryLogRepository
    {
        public EntryLogRepository(MyAppContext context) : base(context)
        {
        }

        public override EntryLog GetById(Guid id)
        {
            return DbSet
                .Include(p => p.User)
                .Include(p => p.Project)
                .FirstOrDefault(p => p.Id == id);
        }
    }
}
