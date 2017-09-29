using FluentValidation;
using MyApp.Domain.Queries;
using System;

namespace MyApp.Domain.Validations
{
    public class AddEntryLogCommandValidation : AbstractValidator<AddEntryLogCommand>
    {
        public AddEntryLogCommandValidation()
        {
            ValidateUserId();
            ValidateProjectId();
        }

        protected void ValidateUserId()
        {
            RuleFor(entryLog => entryLog.UserId)
                .NotEqual(Guid.Empty);
        }

        protected void ValidateProjectId()
        {
            RuleFor(entryLog => entryLog.ProjectId)
                .NotEqual(Guid.Empty);
        }
    }
}
