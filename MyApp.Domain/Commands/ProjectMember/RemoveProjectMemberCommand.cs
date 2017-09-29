using MyApp.Domain.Core.Commands;
using MyApp.Domain.Validations;
using System;

namespace MyApp.Domain.Queries
{
    public class RemoveProjectMemberCommand : Command
    {
        public Guid Id { get; set; }

        public RemoveProjectMemberCommand(Guid id)
        {
            this.Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveProjectMemberCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
