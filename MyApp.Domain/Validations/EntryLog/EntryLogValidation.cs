using FluentValidation;
using MyApp.Domain.Commands;
using System;

namespace MyApp.Domain.Validations
{
    public abstract class EntryLogValidation<T> : AbstractValidator<T> where T : EntryLogCommand
    {
        protected void ValidateId()
        {
            RuleFor(entryLog => entryLog.Id)
                .NotEqual(Guid.Empty);
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
