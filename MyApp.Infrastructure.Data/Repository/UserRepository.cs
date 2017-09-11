using MyApp.Domain.Interfaces;
using MyApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using MyApp.Infrastructure.Data.Context;

namespace MyApp.Infrastructure.Data.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(MyAppContext context) : base(context)
        {
        }
    }
}
