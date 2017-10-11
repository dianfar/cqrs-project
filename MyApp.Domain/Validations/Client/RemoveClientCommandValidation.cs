using FluentValidation;
using MyApp.Domain.Commands;
using System;

namespace MyApp.Domain.Validations
{
    public class RemoveClientCommandValidation : AbstractValidator<RemoveClientCommand>
    {
        public RemoveClientCommandValidation()
        {
            ValidateId();
        }

        protected void ValidateId()
        {
            RuleFor(client => client.Id)
                .NotEqual(Guid.Empty);
        }
    }
}
