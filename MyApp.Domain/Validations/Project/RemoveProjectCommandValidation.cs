using FluentValidation;
using MyApp.Domain.Commands;
using System;

namespace MyApp.Domain.Validations
{
    public class RemoveProjectCommandValidation : AbstractValidator<RemoveProjectCommand>
    {
        public RemoveProjectCommandValidation()
        {
            ValidateId();
        }

        protected void ValidateId()
        {
            RuleFor(product => product.Id)
                .NotEqual(Guid.Empty);
        }
    }
}
