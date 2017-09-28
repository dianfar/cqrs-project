using MyApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using MyApp.Domain.Core.Interfaces;

namespace MyApp.Domain.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByEmail(string email);
    }
}
