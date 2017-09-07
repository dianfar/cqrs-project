using MyApp.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Models
{
    public class Project : Entity
    {
        public Project(Guid id, string name, string description, DateTime completionDate, bool active)
        {
            Id = id;
            Name = name;
            Description = description;
            CompletionDate = completionDate;
            Active = active;
        }

        protected Project() { }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public DateTime CompletionDate { get; private set; }

        public bool Active { get; private set; }

        public Client Client { get; private set; }
    }
}
