using Domain.Commands;
using Domain.Core.Bus;
using Domain.Core.Notifications;
using Domain.Events;
using Domain.Interfaces;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CommandHandlers
{
    public class CustomerCommandHandler : CommandHandler,
            INotificationHandler<RegisterNewCustomerCommand>,
            INotificationHandler<UpdateCustomerCommand>,
            INotificationHandler<RemoveCustomerCommand>
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IMediatorHandler mediatorHandler;

        public CustomerCommandHandler(ICustomerRepository customerRepository,
                                      IUnitOfWork unitOfWork,
                                      IMediatorHandler mediatorHandler,
                                      INotificationHandler<DomainNotification> notifications) : base(unitOfWork, mediatorHandler, notifications)
        {
            this.customerRepository = customerRepository;
            this.mediatorHandler = mediatorHandler;
        }

        public void Handle(RegisterNewCustomerCommand message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            var customer = new Customer(Guid.NewGuid(), message.Name, message.Email, message.BirthDate);

            if (customerRepository.GetByEmail(customer.Email) != null)
            {
                mediatorHandler.RaiseEvent(new DomainNotification(message.MessageType, "The customer e-mail has already been taken."));
                return;
            }

            customerRepository.Add(customer);

            if (Commit())
            {
                mediatorHandler.RaiseEvent(new CustomerRegisteredEvent(customer.Id, customer.Name, customer.Email, customer.BirthDate));
            }
        }

        public void Handle(UpdateCustomerCommand message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            var customer = new Customer(message.Id, message.Name, message.Email, message.BirthDate);
            var existingCustomer = customerRepository.GetByEmail(customer.Email);

            if (existingCustomer != null && existingCustomer.Id != customer.Id)
            {
                if (!existingCustomer.Equals(customer))
                {
                    mediatorHandler.RaiseEvent(new DomainNotification(message.MessageType, "The customer e-mail has already been taken."));
                    return;
                }
            }

            customerRepository.Update(customer);

            if (Commit())
            {
                mediatorHandler.RaiseEvent(new CustomerUpdatedEvent(customer.Id, customer.Name, customer.Email, customer.BirthDate));
            }
        }

        public void Handle(RemoveCustomerCommand message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            customerRepository.Remove(message.Id);

            if (Commit())
            {
                mediatorHandler.RaiseEvent(new CustomerRemovedEvent(message.Id));
            }
        }

        public void Dispose()
        {
            customerRepository.Dispose();
        }
    }
}
