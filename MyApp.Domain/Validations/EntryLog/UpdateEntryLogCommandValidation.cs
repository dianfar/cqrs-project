using FluentValidation;
using MyApp.Domain.Queries;
using System;

namespace MyApp.Domain.Validations
{
    public class UpdateEntryLogCommandValidation : AbstractValidator<UpdateEntryLogCommand>
    {
        public UpdateEntryLogCommandValidation()
        {
            ValidateId();
            ValidateUserId();
            ValidateProjectId();
        }

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
