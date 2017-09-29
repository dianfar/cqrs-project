using FluentValidation;
using MyApp.Domain.Queries;
using System;

namespace MyApp.Domain.Validations
{
    public class UpdateProjectCommandValidation : AbstractValidator<UpdateProjectCommand>
    {
        public UpdateProjectCommandValidation()
        {
            ValidateId();
            ValidateName();
        }

        protected void ValidateId()
        {
            RuleFor(product => product.Id)
                .NotEqual(Guid.Empty);
        }

        protected void ValidateName()
        {
            RuleFor(product => product.Name)
                .NotEmpty().WithMessage("Please ensure you have entered the Name")
                .Length(2, 100).WithMessage("The Name must have between 2 and 100 characters");
        }
    }
}
