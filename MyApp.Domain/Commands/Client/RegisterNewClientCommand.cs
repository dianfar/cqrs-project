using MyApp.Domain.Core.Commands;
using MyApp.Domain.Validations;

namespace MyApp.Domain.Commands
{
    public class RegisterNewClientCommand : Command
    {
        public string Name { get; protected set; }

        public string Description { get; protected set; }

        public RegisterNewClientCommand(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewClientCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
