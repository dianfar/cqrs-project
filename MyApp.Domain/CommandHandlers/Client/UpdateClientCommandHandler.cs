using MediatR;
using MyApp.Domain.Core.Bus;
using MyApp.Domain.Core.Interfaces;
using MyApp.Domain.Core.Notifications;
using MyApp.Domain.Interfaces;
using MyApp.Domain.Models;
using MyApp.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Domain.CommandHandlers
{
    public class UpdateClientCommandHandler : ActionHandler, IRequestHandler<UpdateClientCommand>
    {
        private readonly IClientRepository clientRepository;

        public UpdateClientCommandHandler(
            IClientRepository clientRepository,
            IUnitOfWork uow,
            IMediatorHandler bus,
            INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            this.clientRepository = clientRepository;
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
    }
}
