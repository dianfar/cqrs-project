using MyApp.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Domain.Commands
{
    public class CreateNewProjectCommand : ProjectCommand
    {
        public CreateNewProjectCommand(string name, string description, DateTime completionDate)
        {
            Name = name;
            Description = description;
            CompletionDate = completionDate;
        }

        public override bool IsValid()
        {
            ValidationResult = new CreateNewProjectCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
