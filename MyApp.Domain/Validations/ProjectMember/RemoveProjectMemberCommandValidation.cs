using FluentValidation;
using MyApp.Domain.Commands;
using System;

namespace MyApp.Domain.Validations
{
    public class RemoveProjectMemberCommandValidation : AbstractValidator<RemoveProjectMemberCommand>
    {
        public RemoveProjectMemberCommandValidation()
        {
            ValidateId();
        }

        protected void ValidateId()
        {
            RuleFor(projectMember => projectMember.Id)
                .NotEqual(Guid.Empty);
        }
    }
}
