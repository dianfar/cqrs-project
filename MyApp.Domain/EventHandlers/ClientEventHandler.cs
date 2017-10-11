using MyApp.Domain.Events;
using MediatR;
using MyApp.Infrastructure.Mail;

namespace MyApp.Domain.EventHandlers
{
    public class ClientEventHandler :
            INotificationHandler<ClientRegisteredEvent>,
            INotificationHandler<ClientUpdatedEvent>,
            INotificationHandler<ClientRemovedEvent>
    {
        private readonly IMailProvider mailProvider;

        public ClientEventHandler(IMailProvider mailProvider)
        {
            this.mailProvider = mailProvider;
        }

        public void Handle(ClientUpdatedEvent message)
        {
            mailProvider.SendMailAsync("Subject", "Content", "myapp-no-reply@myapp.com", "Sender", message.Email);
        }

        public void Handle(ClientRegisteredEvent message)
        {
            mailProvider.SendMailAsync("Subject", "Content", "myapp-no-reply@myapp.com", "Sender", message.Email);
        }

        public void Handle(ClientRemovedEvent message)
        {
            // Send some see you soon e-mail
        }
    }
}
