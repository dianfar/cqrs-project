using MyApp.Domain.Core.Commands;
using MyApp.Domain.Validations;
using System;

namespace MyApp.Domain.Queries
{
    public class RegisterNewUserCommand : Command
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public string Email { get; set; }
        public Guid RoleId { get; set; }
        public string Password { get; set; }

        public RegisterNewUserCommand(string name, string email, Guid roleId, string password)
        {
            this.Name = name;
            this.Email = email;
            this.RoleId = roleId;
            this.Password = password;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewUserCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
