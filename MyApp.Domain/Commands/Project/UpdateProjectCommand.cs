using MyApp.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Domain.Commands
{
    public class UpdateProjectCommand : ProjectCommand
    {
        public UpdateProjectCommand(Guid id, string name, string description, DateTime completionDate)
        {
            Id = id;
            Name = name;
            Description = description;
            CompletionDate = completionDate;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateProjectCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
