using MediatR;
using MyApp.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using MyApp.Domain.Core.Bus;
using MyApp.Domain.Core.Interfaces;
using MyApp.Domain.Core.Notifications;
using MyApp.Domain.Interfaces;

namespace MyApp.Domain.CommandHandlers
{
    public class RemoveClientCommandHandler : ActionHandler, IRequestHandler<RemoveClientCommand>
    {
        private readonly IClientRepository clientRepository;

        public RemoveClientCommandHandler(
            IClientRepository clientRepository,
            IUnitOfWork uow,
            IMediatorHandler bus,
            INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            this.clientRepository = clientRepository;
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
    }
}
