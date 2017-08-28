using MyApp.Domain.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.EventHandlers
{
    public class CustomerEventHandler :
            INotificationHandler<CustomerRegisteredEvent>,
            INotificationHandler<CustomerUpdatedEvent>,
            INotificationHandler<CustomerRemovedEvent>
    {
        public void Handle(CustomerUpdatedEvent message)
        {
            // Send some notification e-mail
        }

        public void Handle(CustomerRegisteredEvent message)
        {
            // Send some greetings e-mail
        }

        public void Handle(CustomerRemovedEvent message)
        {
            // Send some see you soon e-mail
        }
    }
}
