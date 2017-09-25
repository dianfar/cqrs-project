using MyApp.Domain.Core.Models;
using System;

namespace MyApp.Domain.Models
{
    public class User : Entity
    {
        public User() { }

        public User(Guid id, string name, bool active, string email, Role role)
        {
            this.Id = id;
            this.Name = name;
            this.Active = active;
            this.Email = email;
            this.Role = role;
        }

        public string Name { get; set; }
        public bool Active { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
    }
}
