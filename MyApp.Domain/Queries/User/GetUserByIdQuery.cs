using MyApp.Domain.Core.Queries;
using MyApp.Domain.Models;
using MyApp.Domain.Validations;
using System;

namespace MyApp.Domain.Queries
{
    public class GetUserByIdQuery : Query<User>
    {
        public Guid Id { get; set; }

        public GetUserByIdQuery(Guid id)
        {
            this.Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new GetUserByIdQueryValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
