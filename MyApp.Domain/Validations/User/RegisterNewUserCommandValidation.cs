using FluentValidation;
using MyApp.Domain.Commands;

namespace MyApp.Domain.Validations
{
    public class RegisterNewUserCommandValidation : AbstractValidator<RegisterNewUserCommand>
    {
        public RegisterNewUserCommandValidation()
        {
            ValidateName();
        }

        protected void ValidateName()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Please ensure you have entered the Name")
                .Length(2, 150).WithMessage("The Name must have between 2 and 150 characters");
        }
    }
}
