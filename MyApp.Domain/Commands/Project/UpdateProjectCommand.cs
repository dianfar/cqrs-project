using MediatR;
using MyApp.Domain.Core.Commands;
using MyApp.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Domain.Commands
{
    public class UpdateProjectCommand : Command
    {
        public Guid Id { get; protected set; }

        public string Name { get; protected set; }

        public string Description { get; protected set; }

        public DateTime CompletionDate { get; protected set; }

        public bool Active { get; protected set; }

        public Guid ClientId { get; protected set; }

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
