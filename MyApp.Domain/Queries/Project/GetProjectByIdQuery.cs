using MyApp.Domain.Core.Queries;
using MyApp.Domain.Models;
using MyApp.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Domain.Queries
{
    public class GetProjectByIdQuery : Query<Project>
    {
        public Guid Id { get; set; }

        public GetProjectByIdQuery(Guid id)
        {
            this.Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new GetProjectByIdQueryValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
