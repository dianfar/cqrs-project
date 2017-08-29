using MyApp.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Domain.Commands
{
    public class CreateNewProductCommand : ProductCommand
    {
        public CreateNewProductCommand(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }

        public override bool IsValid()
        {
            ValidationResult = new CreateNewProductCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
