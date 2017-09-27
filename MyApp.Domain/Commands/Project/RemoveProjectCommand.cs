using MediatR;
using MyApp.Domain.Core.Commands;
using MyApp.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Domain.Commands
{
    public class RemoveProjectCommand : Command
    {
        public Guid Id { get; protected set; }

        public RemoveProjectCommand(Guid id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveProjectCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
