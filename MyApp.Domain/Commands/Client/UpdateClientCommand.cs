using MyApp.Domain.Core.Commands;
using MyApp.Domain.Validations;
using System;

namespace MyApp.Domain.Queries
{
    public class UpdateClientCommand : Command
    {
        public Guid Id { get; protected set; }

        public string Name { get; protected set; }

        public string Description { get; protected set; }

        public UpdateClientCommand(Guid id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateClientCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
