using MyApp.Domain.Validations;
using System;
using MyApp.Domain.Core.Commands;

namespace MyApp.Domain.Queries
{
    public class RemoveClientCommand : Command
    {
        public Guid Id { get; protected set; }

        public RemoveClientCommand(Guid id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveClientCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
