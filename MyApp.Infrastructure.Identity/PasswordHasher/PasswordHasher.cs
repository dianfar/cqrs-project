using System;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace MyApp.Infrastructure.Identity.PasswordHasher
{
    public class PasswordHasher : IPasswordHasher
    {
        private byte[] salt;
        private string saltString;

        public PasswordHasher()
        {
            salt = new byte[128 / 8];
            using (var randomNumberGenerator = RandomNumberGenerator.Create())
            {
                randomNumberGenerator.GetBytes(salt);
            }

            saltString = Convert.ToBase64String(salt);
        }

        public string GetSalt()
        {
            return saltString;
        }

        public string HashPassword(string password)
        {
            return this.Hash(password, this.salt);
        }

        public string HashPassword(string password, string salt)
        {
            return this.Hash(password, Convert.FromBase64String(salt));
        }

        private string Hash(string password, byte[] salt)
        {
            string hashed = Convert.ToBase64String(
                KeyDerivation.Pbkdf2(
                    password: password,
                    salt: salt,
                    prf: KeyDerivationPrf.HMACSHA1,
                    iterationCount: 10000,
                    numBytesRequested: 256 / 8));

            return hashed;
        }
    }
}
