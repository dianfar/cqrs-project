using FluentValidation;
using MyApp.Domain.Queries;
using System;

namespace MyApp.Domain.Validations
{
    public class RemoveUserCommandValidation : AbstractValidator<RemoveUserCommand>
    {
        public RemoveUserCommandValidation()
        {
            ValidateId();
        }

        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }
    }
}
