using MyApp.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Domain.Validations
{
    public class RemoveUserCommandValidation : UserValidation<RemoveUserCommand>
    {
        public RemoveUserCommandValidation()
        {
            ValidateId();
        }
    }
}
