using MyApp.Domain.Models;
using MyApp.Domain.Validations;
using System;

namespace MyApp.Domain.Commands
{
    public class AddProjectMemberCommand : ProjectMemberCommand
    {
        public AddProjectMemberCommand(Project project, User user)
        {
            this.Project = project;
            this.User = user;
        }

        public override bool IsValid()
        {
            ValidationResult = new AddProjectMemberCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
