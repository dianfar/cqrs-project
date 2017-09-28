using Microsoft.EntityFrameworkCore;
using MyApp.Infrastructure.Data.Context;
using System;
using System.Linq;
using MyApp.Domain.Core.Interfaces;

namespace MyApp.Infrastructure.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly MyAppContext databaseContext;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(MyAppContext context)
        {
            databaseContext = context;
            DbSet = databaseContext.Set<TEntity>();
        }

        public virtual void Add(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public virtual TEntity GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        public virtual void Update(TEntity obj)
        {
            DbSet.Update(obj);
        }

        public virtual void Remove(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public int SaveChanges()
        {
            return databaseContext.SaveChanges();
        }

        public void Dispose()
        {
            databaseContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
