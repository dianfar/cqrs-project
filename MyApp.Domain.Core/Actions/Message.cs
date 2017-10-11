using FluentValidation.Results;
using System;

namespace MyApp.Domain.Core.Events
{
    public abstract class Message
    {
        public string MessageType { get; protected set; }
        public Guid AggregateId { get; protected set; }
        public DateTime Timestamp { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        protected Message()
        {
            MessageType = GetType().Name;
            Timestamp = DateTime.Now;
        }
    }
}
