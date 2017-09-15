using MyApp.Domain.Core.Commands;
using MyApp.Domain.Models;
using System;

namespace MyApp.Domain.Commands
{
    public abstract class ProjectMemberCommand : Command
    {
        public Guid Id { get; set; }

        public Guid ProjectId { get; set; }

        public Guid UserId { get; set; }
    }
}
