using MyApp.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Domain.Models
{
    public class User : Entity
    {
        public User(Guid id, string name, bool active, string email)
        {
            this.Id = id;
            this.Name = name;
            this.Active = active;
            this.Email = email;
        }

        protected User() { }

        public string Name { get; set; }
        public bool Active { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
    }
}
