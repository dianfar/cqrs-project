using FluentValidation;
using MyApp.Domain.Commands;
using System;

namespace MyApp.Domain.Validations
{
    public class AddProjectMemberCommandValidation : AbstractValidator<AddProjectMemberCommand>
    {
        public AddProjectMemberCommandValidation()
        {
            ValidateProjectId();
            ValidateUserId();
        }

        protected void ValidateProjectId()
        {
            RuleFor(projectMember => projectMember.ProjectId)
                .NotEqual(Guid.Empty);
        }

        protected void ValidateUserId()
        {
            RuleFor(projectMember => projectMember.UserId)
                .NotEqual(Guid.Empty);
        }
    }
}
