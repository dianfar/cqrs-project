using FluentValidation;
using MyApp.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Domain.Validations
{
    public class GetProjectsByUserQueryValidation : AbstractValidator<GetProjectsByUserQuery>
    {
        public GetProjectsByUserQueryValidation()
        {
            ValidateUserId();
        }

        private void ValidateUserId()
        {
            RuleFor(project => project.UserId)
                .NotEqual(Guid.Empty);
        }
    }
}
