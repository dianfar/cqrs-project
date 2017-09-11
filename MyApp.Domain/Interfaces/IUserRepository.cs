using MyApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Domain.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
    }
}
