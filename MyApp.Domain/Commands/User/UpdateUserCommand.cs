using MyApp.Domain.Core.Commands;
using MyApp.Domain.Validations;
using System;

namespace MyApp.Domain.Queries
{
    public class UpdateUserCommand : Command
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public string Email { get; set; }
        public Guid RoleId { get; set; }
        public string Password { get; set; }

        public UpdateUserCommand(Guid id, string name, bool active, string email, Guid roleId)
        {
            this.Id = id;
            this.Name = name;
            this.Active = active;
            this.Email = email;
            this.RoleId = roleId;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateUserCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
