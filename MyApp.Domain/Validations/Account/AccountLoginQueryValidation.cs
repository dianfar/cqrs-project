using FluentValidation;
using MyApp.Domain.Queries;

namespace MyApp.Domain.Validations
{
    public class AccountLoginQueryValidation : AbstractValidator<AccountLoginQuery>
    {
        public AccountLoginQueryValidation()
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
