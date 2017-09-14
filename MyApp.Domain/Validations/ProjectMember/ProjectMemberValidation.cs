using FluentValidation;
using MyApp.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Domain.Validations
{
    public abstract class ProjectMemberValidation<T> : AbstractValidator<T> where T : ProjectMemberCommand
    {
        protected void ValidateId()
        {
            RuleFor(projectMember => projectMember.Id)
                .NotEqual(Guid.Empty);
        }

        protected void ValidateProjectId()
        {
            RuleFor(projectMember => projectMember.Project.Id)
                .NotEqual(Guid.Empty);
        }

        protected void ValidateUserId()
        {
            RuleFor(projectMember => projectMember.User.Id)
                .NotEqual(Guid.Empty);
        }
    }
}
