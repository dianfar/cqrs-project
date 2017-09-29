using FluentValidation;
using MyApp.Domain.Queries;
using System;

namespace MyApp.Domain.Validations
{
    public class GetClientByIdQueryValidation : AbstractValidator<GetClientByIdQuery>
    {
        public GetClientByIdQueryValidation()
        {
            ValidateId();
        }

        private void ValidateId()
        {
            RuleFor(client => client.Id)
                .NotEqual(Guid.Empty);
        }
    }
}
