using FluentValidation;
using MyApp.Domain.Commands;

namespace MyApp.Domain.Validations
{
    public class AccountLoginCommandValidation : AbstractValidator<AccountLoginCommand>
    {
        public AccountLoginCommandValidation()
        {
            ValidateEmail();
            ValidatePassword();
        }

        protected void ValidateEmail()
        {
            RuleFor(account => account.Email)
                .NotEmpty().WithMessage("Please ensure you have entered an Email");
        }

        protected void ValidatePassword()
        {
            RuleFor(account => account.Password)
                .NotEmpty().WithMessage("Please ensure you have entered Passwordl");
        }
    }
}
