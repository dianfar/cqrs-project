using MyApp.Domain.Commands;
using MyApp.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Domain.Validations
{
    public class CreateNewProductCommandValidation : ProductValidation<CreateNewProductCommand>
    {
        public CreateNewProductCommandValidation()
        {
            ValidateName();
        }
    }
}
