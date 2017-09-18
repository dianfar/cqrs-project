using MyApp.Domain.Validations;
using System;

namespace MyApp.Domain.Commands
{
    public class AddEntryLogCommand : EntryLogCommand
    {
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
