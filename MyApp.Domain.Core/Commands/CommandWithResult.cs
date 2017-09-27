using MyApp.Domain.Core.Events;
using FluentValidation.Results;
using System;
using MediatR;

namespace MyApp.Domain.Core.Commands
{
    public abstract class CommandWithResult<T> : Message, IRequest<T>
    {
        public DateTime Timestamp { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        protected CommandWithResult()
        {
            Timestamp = DateTime.Now;
        }

        public abstract bool IsValid();
    }
}
