using MyApp.Domain.Core.Queries;
using MyApp.Domain.Models;
using MyApp.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyApp.Domain.Queries
{
    public class GetProjectsByUserQuery : Query<IQueryable<Project>>
    {
        public Guid UserId { get; set; }

        public GetProjectsByUserQuery(Guid userId)
        {
            UserId = userId;
        }

        public override bool IsValid()
        {
            ValidationResult = new GetProjectsByUserQueryValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
