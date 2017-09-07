using MyApp.Domain.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Domain.Validations
{
    public abstract class ProjectValidation<T> : AbstractValidator<T> where T : ProjectCommand
    {
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
