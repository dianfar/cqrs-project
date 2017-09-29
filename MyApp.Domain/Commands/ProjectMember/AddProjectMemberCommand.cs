using MyApp.Domain.Core.Commands;
using MyApp.Domain.Validations;
using System;

namespace MyApp.Domain.Queries
{
    public class AddProjectMemberCommand : Command
    {
        public Guid ProjectId { get; set; }

        public Guid UserId { get; set; }

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
