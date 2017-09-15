using MyApp.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Domain.Validations
{
    public class RemoveProjectCommandValidation : ProjectValidation<RemoveProjectCommand>
    {
        public RemoveProjectCommandValidation()
        {
            ValidateId();
        }
    }
}
