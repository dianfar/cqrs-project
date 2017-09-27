using MyApp.Domain.Core.Commands;
using MyApp.Domain.Models;
using MyApp.Domain.Validations;

namespace MyApp.Domain.Commands
{
    public class AccountLoginCommand : CommandWithResult<User>
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public AccountLoginCommand(string email, string password)
        {
            this.Email = email;
            this.Password = password;
        }

        public override bool IsValid()
        {
            ValidationResult = new AccountLoginCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
