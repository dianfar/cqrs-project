using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Infrastructure.Identity.PasswordHasher
{
    public interface IPasswordHasher
    {
        string GetSalt();
        string HashPassword(string password);
        string HashPassword(string password, string salt);
    }
}
