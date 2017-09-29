using MyApp.Domain.Core.Commands;
using MyApp.Domain.Validations;
using System;

namespace MyApp.Domain.Queries
{
    public class UpdateEntryLogCommand : Command
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public Guid ProjectId { get; set; }

        public DateTime EntryDate { get; set; }

        public decimal Hours { get; set; }

        public string Description { get; set; }

        public UpdateEntryLogCommand(Guid id, Guid userId, Guid projectId, DateTime entryDate, decimal Hours, string description)
        {
            this.Id = id;
            this.UserId = userId;
            this.ProjectId = projectId;
            this.EntryDate = entryDate;
            this.Hours = Hours;
            this.Description = description;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateEntryLogCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
