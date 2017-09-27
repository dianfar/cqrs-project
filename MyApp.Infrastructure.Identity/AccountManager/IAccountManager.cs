using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Infrastructure.Identity.UserManager
{
    public interface IAccountManager
    {
        bool Login(string email, string password);
    }
}
