using MyApp.Domain.Core.Commands;
using MyApp.Domain.Validations;
using System;

namespace MyApp.Domain.Commands
{
    public class RemoveEntryLogCommand : Command
    {
        public Guid Id { get; set; }

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
