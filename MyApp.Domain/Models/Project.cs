using MyApp.Domain.Core.Models;
using System;

namespace MyApp.Domain.Models
{
    public class Project : Entity
    {
        public Project(Guid id, string name, string description, DateTime completionDate, bool active, Client client)
        {
            Id = id;
            Name = name;
            Description = description;
            CompletionDate = completionDate;
            Active = active;
            Client = client;
        }

        protected Project() { }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public DateTime CompletionDate { get; private set; }

        public bool Active { get; private set; }

        public Client Client { get; private set; }
    }
}
