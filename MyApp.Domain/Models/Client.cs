using MyApp.Domain.Core.Models;
using System;

namespace MyApp.Domain.Models
{
    public class Client : Entity
    {
        public Client() { }

        public Client(Guid id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
    }
}
