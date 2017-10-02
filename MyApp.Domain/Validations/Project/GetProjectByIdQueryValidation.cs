using FluentValidation;
using MyApp.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Domain.Validations
{
    public class GetProjectByIdQueryValidation : AbstractValidator<GetProjectByIdQuery>
    {
        public GetProjectByIdQueryValidation()
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
