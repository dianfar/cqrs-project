using MyApp.Domain.Core.Queries;
using MyApp.Domain.Models;
using MyApp.Domain.Validations;

namespace MyApp.Domain.Queries
{
    public class AccountLoginQuery : Query<User>
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public AccountLoginQuery(string email, string password)
        {
            this.Email = email;
            this.Password = password;
        }

        public override bool IsValid()
        {
            ValidationResult = new AccountLoginQueryValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
