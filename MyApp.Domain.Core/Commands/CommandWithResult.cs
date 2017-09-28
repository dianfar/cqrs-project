using MyApp.Domain.Core.Events;
using FluentValidation.Results;
using System;
using MediatR;

namespace MyApp.Domain.Core.Commands
{
    public abstract class Query<T> : Message, IRequest<T>
    {
        public DateTime Timestamp { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        protected Query()
        {
            Timestamp = DateTime.Now;
        }

        public abstract bool IsValid();
    }
}
