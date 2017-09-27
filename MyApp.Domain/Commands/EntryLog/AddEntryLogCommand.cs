using MyApp.Domain.Core.Commands;
using MyApp.Domain.Validations;
using System;

namespace MyApp.Domain.Commands
{
    public class AddEntryLogCommand : Command
    {
        public Guid UserId { get; set; }

        public Guid ProjectId { get; set; }

        public DateTime EntryDate { get; set; }

        public decimal Hours { get; set; }

        public string Description { get; set; }

        public AddEntryLogCommand(Guid userId, Guid projectId, DateTime entryDate, decimal Hours, string description)
        {
            this.UserId = userId;
            this.ProjectId = projectId;
            this.EntryDate = entryDate;
            this.Hours = Hours;
            this.Description = description;
        }

        public override bool IsValid()
        {
            ValidationResult = new AddEntryLogCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
