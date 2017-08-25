using Domain.Core.Commands;
using Domain.Interfaces;
using MyApp.Infrastructure.Data.Context;

namespace MyApp.Infrastructure.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyAppContext _context;

        public UnitOfWork(MyAppContext context)
        {
            _context = context;
        }

        public CommandResponse Commit()
        {
            var rowsAffected = _context.SaveChanges();
            return new CommandResponse(rowsAffected > 0);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
