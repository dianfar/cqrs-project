using MyApp.Domain.Queries;
using MyApp.Domain.Core.Bus;
using MyApp.Domain.Core.Notifications;
using MyApp.Domain.Interfaces;
using MyApp.Domain.Models;
using MediatR;
using System;
using MyApp.Domain.Core.Interfaces;

namespace MyApp.Domain.CommandHandlers
{
    public class ClientCommandHandler : ActionHandler,
            IRequestHandler<RegisterNewClientCommand>,
            IRequestHandler<UpdateClientCommand>,
            IRequestHandler<RemoveClientCommand>
    {
        private readonly IClientRepository clientRepository;
        private readonly IMediatorHandler mediatorHandler;

        public ClientCommandHandler(IClientRepository clientRepository,
                                      IUnitOfWork unitOfWork,
                                      IMediatorHandler mediatorHandler,
                                      INotificationHandler<DomainNotification> notifications) : base(unitOfWork, mediatorHandler, notifications)
        {
            this.clientRepository = clientRepository;
            this.mediatorHandler = mediatorHandler;
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

        public void Handle(UpdateClientCommand message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            var client = new Client(message.Id, message.Name, message.Description);

            clientRepository.Update(client);
            Commit();
        }

        public void Handle(RemoveClientCommand message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            clientRepository.Remove(message.Id);
            Commit();
        }

        public void Dispose()
        {
            clientRepository.Dispose();
        }
    }
}
