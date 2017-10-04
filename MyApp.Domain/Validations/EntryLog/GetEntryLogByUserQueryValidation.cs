using FluentValidation;
using MyApp.Domain.Queries;
using System;

namespace MyApp.Domain.Validations
{
    public class GetEntryLogByUserQueryValidation : AbstractValidator<GetEntryLogByUserQuery>
    {
        public GetEntryLogByUserQueryValidation()
        {
            ValidateUserId();
        }

        private void ValidateUserId()
        {
            RuleFor(entryLog => entryLog.UserId)
                .NotEqual(Guid.Empty);
        }
    }
}
