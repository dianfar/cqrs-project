using MyApp.Domain.Core.Events;
using System;

namespace MyApp.Domain.Events
{
    public class ClientRegisteredEvent : Event
    {
        public ClientRegisteredEvent(Guid id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
            AggregateId = id;
        }
        public Guid Id { get; set; }

        public string Name { get; private set; }

        public string Email { get; private set; }
    }
}
