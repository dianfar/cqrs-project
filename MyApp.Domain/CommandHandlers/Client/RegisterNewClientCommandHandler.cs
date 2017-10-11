using MediatR;
using MyApp.Domain.Queries;
using System;
using MyApp.Domain.Core.Bus;
using MyApp.Domain.Core.Interfaces;
using MyApp.Domain.Core.Notifications;
using MyApp.Domain.Interfaces;
using MyApp.Domain.Models;

namespace MyApp.Domain.CommandHandlers
{
    public class RegisterNewClientCommandHandler : ActionHandler, IRequestHandler<RegisterNewClientCommand>
    {
        private readonly IClientRepository clientRepository;

        public RegisterNewClientCommandHandler(
            IClientRepository clientRepository,
            IUnitOfWork uow, 
            IMediatorHandler bus, 
            INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            this.clientRepository = clientRepository;
        }

        public void Handle(RegisterNewClientCommand message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            var client = new Client(Guid.NewGuid(), message.Name, message.Description);

            clientRepository.Add(client);
            Commit();
        }
    }
}
