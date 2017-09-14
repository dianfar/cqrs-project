using MyApp.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Domain.Commands
{
    public class RemoveProjectMemberCommand : ProjectMemberCommand
    {
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
