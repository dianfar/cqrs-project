using MyApp.Domain.Core.Commands;
using System;

namespace MyApp.Domain.Commands
{
    public abstract class EntryLogCommand : Command
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public Guid ProjectId { get; set; }

        public DateTime EntryDate { get; set; }

        public decimal Hours { get; set; }

        public string Description { get; set; }
    }
}
