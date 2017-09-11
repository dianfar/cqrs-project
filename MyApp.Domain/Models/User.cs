using MyApp.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Domain.Models
{
    public class User : Entity
    {
        public User(string name, bool active, string email)
        {
            this.Name = name;
            this.Active = active;
            this.Email = email;
        }

        protected User() { }

        public string Name { get; set; }
        public bool Active { get; set; }
        public string Email { get; set; }
    }
}
