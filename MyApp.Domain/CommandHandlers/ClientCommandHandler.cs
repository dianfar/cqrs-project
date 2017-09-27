using MyApp.Domain.Commands;
using MyApp.Domain.Core.Bus;
using MyApp.Domain.Core.Notifications;
using MyApp.Domain.Events;
using MyApp.Domain.Interfaces;
using MyApp.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.CommandHandlers
{
    public class ClientCommandHandler : CommandHandler,
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

            ////if (clientRepository.GetByEmail(customer.Email) != null)
            ////{
            ////    mediatorHandler.RaiseEvent(new DomainNotification(message.MessageType, "The customer e-mail has already been taken."));
            ////    return;
            ////}

            clientRepository.Add(client);

            if (Commit())
            {
                ////mediatorHandler.RaiseEvent(new CustomerRegisteredEvent(client.Id, client.Name, client.Email, client.BirthDate));
            }
        }

        public void Handle(UpdateClientCommand message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            var customer = new Client(message.Id, message.Name, message.Description);
            //var existingCustomer = clientRepository.GetByEmail(customer.Email);

            //if (existingCustomer != null && existingCustomer.Id != customer.Id)
            //{
            //    if (!existingCustomer.Equals(customer))
            //    {
            //        mediatorHandler.RaiseEvent(new DomainNotification(message.MessageType, "The customer e-mail has already been taken."));
            //        return;
            //    }
            //}

            clientRepository.Update(customer);

            if (Commit())
            {
                ////mediatorHandler.RaiseEvent(new CustomerUpdatedEvent(customer.Id, customer.Name, customer.Email, customer.BirthDate));
            }
        }

        public void Handle(RemoveClientCommand message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            clientRepository.Remove(message.Id);

            if (Commit())
            {
                mediatorHandler.RaiseEvent(new ClientRemovedEvent(message.Id));
            }
        }

        public void Dispose()
        {
            clientRepository.Dispose();
        }
    }
}
