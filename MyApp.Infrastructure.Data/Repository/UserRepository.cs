using MyApp.Domain.Interfaces;
using MyApp.Domain.Models;
using System;
using System.Linq;
using MyApp.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace MyApp.Infrastructure.Data.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(MyAppContext context) : base(context)
        {
        }

        public override User GetById(Guid id)
        {
            return DbSet.Include(p => p.Role).FirstOrDefault(p => p.Id == id);
        }
    }
}
