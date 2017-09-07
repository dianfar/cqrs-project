using MyApp.Domain.Events;
using MediatR;

namespace MyApp.Domain.EventHandlers
{
    public class ClientEventHandler :
            INotificationHandler<ClientRegisteredEvent>,
            INotificationHandler<ClientUpdatedEvent>,
            INotificationHandler<ClientRemovedEvent>
    {
        public void Handle(ClientUpdatedEvent message)
        {
            // Send some notification e-mail
        }

        public void Handle(ClientRegisteredEvent message)
        {
            // Send some greetings e-mail
        }

        public void Handle(ClientRemovedEvent message)
        {
            // Send some see you soon e-mail
        }
    }
}
