using FluentValidation;
using MyApp.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Domain.Validations
{
    public class GetUserByIdQueryValidation : AbstractValidator<GetUserByIdQuery>
    {
        public GetUserByIdQueryValidation()
        {
            ValidateId();
        }

        private void ValidateId()
        {
            RuleFor(user => user.Id)
                .NotEqual(Guid.Empty);
        }
    }
}
