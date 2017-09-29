using MyApp.Domain.Core.Queries;
using MyApp.Domain.Models;
using MyApp.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Domain.Queries
{
    public class GetClientByIdQuery : Query<Client>
    {
        public Guid Id { get; set; }

        public GetClientByIdQuery(Guid id)
        {
            this.Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new GetClientByIdQueryValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
