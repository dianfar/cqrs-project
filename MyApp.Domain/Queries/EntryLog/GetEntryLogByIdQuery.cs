using MyApp.Domain.Core.Queries;
using MyApp.Domain.Models;
using MyApp.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyApp.Domain.Queries
{
    public class GetEntryLogByIdQuery : Query<EntryLog>
    {
        public Guid Id { get; set; }

        public GetEntryLogByIdQuery(Guid id)
        {
            this.Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new GetEntryLogByIdQueryValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
