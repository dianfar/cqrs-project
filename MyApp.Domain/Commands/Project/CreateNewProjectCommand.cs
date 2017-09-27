using MediatR;
using MyApp.Domain.Core.Commands;
using MyApp.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Domain.Commands
{
    public class CreateNewProjectCommand : Command
    {
        public string Name { get; protected set; }

        public string Description { get; protected set; }

        public DateTime CompletionDate { get; protected set; }

        public Guid ClientId { get; protected set; }

        public CreateNewProjectCommand(string name, string description, DateTime completionDate, Guid clientId)
        {
            Name = name;
            Description = description;
            CompletionDate = completionDate;
            ClientId = clientId;
        }

        public override bool IsValid()
        {
            ValidationResult = new CreateNewProjectCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
