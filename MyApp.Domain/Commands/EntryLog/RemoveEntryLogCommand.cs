using MyApp.Domain.Validations;
using System;

namespace MyApp.Domain.Commands
{
    public class RemoveEntryLogCommand : EntryLogCommand
    {
        public RemoveEntryLogCommand(Guid id)
        {
            this.Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveEntryLogCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
