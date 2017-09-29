using FluentValidation;
using MyApp.Domain.Queries;
using System;

namespace MyApp.Domain.Validations
{
    public class RemoveEntryLogCommandValidation : AbstractValidator<RemoveEntryLogCommand>
    {
        public RemoveEntryLogCommandValidation()
        {
            ValidateId();
        }

        protected void ValidateId()
        {
            RuleFor(entryLog => entryLog.Id)
                .NotEqual(Guid.Empty);
        }
    }
}
