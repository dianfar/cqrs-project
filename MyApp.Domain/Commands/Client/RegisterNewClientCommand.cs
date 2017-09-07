using MyApp.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Commands
{
    public class RegisterNewClientCommand : ClientCommand
    {
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
