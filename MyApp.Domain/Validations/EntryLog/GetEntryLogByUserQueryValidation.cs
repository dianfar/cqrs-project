using FluentValidation;
using MyApp.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Text;

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
