using MyApp.Domain.Validations;
using System;

namespace MyApp.Domain.Commands
{
    public class UpdateEntryLogCommand : EntryLogCommand
    {
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
