using MyApp.Domain.Core.Commands;
using MyApp.Domain.Core.Interfaces;
using MyApp.Infrastructure.Data.Context;

namespace MyApp.Infrastructure.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyAppContext context;

        public UnitOfWork(MyAppContext context)
        {
            this.context = context;
        }

        public ActionResponse Commit()
        {
            var rowsAffected = context.SaveChanges();
            return new ActionResponse(rowsAffected > 0);
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
