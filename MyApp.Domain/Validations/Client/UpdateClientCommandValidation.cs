using FluentValidation;
using MyApp.Domain.Commands;
using System;

namespace MyApp.Domain.Validations
{
    public class UpdateClientCommandValidation : AbstractValidator<UpdateClientCommand>
    {
        public UpdateClientCommandValidation()
        {
            ValidateId();
            ValidateName();
        }

        protected void ValidateId()
        {
            RuleFor(client => client.Id)
                .NotEqual(Guid.Empty);
        }

        protected void ValidateName()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Please ensure you have entered the Name")
                .Length(2, 150).WithMessage("The Name must have between 2 and 150 characters");
        }
    }
}
