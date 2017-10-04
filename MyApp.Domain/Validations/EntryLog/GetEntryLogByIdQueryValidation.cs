using FluentValidation;
using MyApp.Domain.Queries;
using System;

namespace MyApp.Domain.Validations
{
    public class GetEntryLogByIdQueryValidation : AbstractValidator<GetEntryLogByIdQuery>
    {
        public GetEntryLogByIdQueryValidation()
        {
            ValidateId();
        }

        private void ValidateId()
        {
            RuleFor(entryLog => entryLog.Id)
                .NotEqual(Guid.Empty);
        }
    }
}
