using MyApp.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Domain.Commands
{
    public class RemoveUserCommand : UserCommand
    {
        public RemoveUserCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            var validationResult = new RemoveUserCommandValidation().Validate(this);
            return validationResult.IsValid;
        }
    }
}
