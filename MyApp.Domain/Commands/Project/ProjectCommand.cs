using MyApp.Domain.Core.Commands;
using System;

namespace MyApp.Domain.Commands
{
    public abstract class ProjectCommand : Command
    {
        public Guid Id { get; protected set; }

        public string Name { get; protected set; }

        public string Description { get; protected set; }

        public DateTime CompletionDate { get; protected set; }

        public bool Active { get; protected set; }
    }
}
