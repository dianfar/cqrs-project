using MyApp.Domain.Core.Commands;
using MyApp.Domain.Models;
using System;

namespace MyApp.Domain.Commands
{
    public abstract class ProjectMemberCommand : Command
    {
        public Guid Id { get; set; }

        public Project Project { get; set; }

        public User User { get; set; }
    }
}
