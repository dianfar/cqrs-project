using MyApp.Domain.Core.Commands;
using MyApp.Domain.Validations;
using System;

namespace MyApp.Domain.Commands
{
    public class RemoveUserCommand : Command
    {
        public Guid Id { get; set; }

        public RemoveUserCommand(Guid id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveUserCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
