using MyApp.Domain.Models;
using MyApp.Domain.Validations;
using System;

namespace MyApp.Domain.Commands
{
    public class AddProjectMemberCommand : ProjectMemberCommand
    {
        public AddProjectMemberCommand(Guid projectId, Guid userId)
        {
            this.ProjectId = projectId;
            this.UserId = userId;
        }

        public override bool IsValid()
        {
            ValidationResult = new AddProjectMemberCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
