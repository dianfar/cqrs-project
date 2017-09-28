using MyApp.Domain.Core.Events;
using FluentValidation.Results;
using System;
using MediatR;

namespace MyApp.Domain.Core.Commands
{
    public abstract class Command : Message, IRequest
    {
        public DateTime Timestamp { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
        }

        public abstract bool IsValid();
    }
}
