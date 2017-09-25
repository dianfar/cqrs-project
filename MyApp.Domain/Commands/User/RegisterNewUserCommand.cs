﻿using MyApp.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Domain.Commands
{
    public class RegisterNewUserCommand : UserCommand
    {
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
