using MyApp.Domain.Core.Queries;
using MyApp.Domain.Models;
using MyApp.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyApp.Domain.Queries
{
    public class GetEntryLogByUserQuery : Query<IQueryable<EntryLog>>
    {
        public Guid UserId { get; set; }

        public GetEntryLogByUserQuery(Guid userId)
        {
            this.UserId = userId;
        }

        public override bool IsValid()
        {
            ValidationResult = new GetEntryLogByUserQueryValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
