using MyApp.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Domain.Validations
{
    public class UpdateUserCommandValidation : UserValidation<UpdateUserCommand>
    {
        public UpdateUserCommandValidation()
        {
            ValidateId();
            ValidateName();
        }
    }
}
