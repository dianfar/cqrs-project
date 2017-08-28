using Domain.CommandHandlers;
using Domain.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Core.Bus;
using Domain.Core.Notifications;
using Domain.Interfaces;
using Domain.Models;

namespace MyApp.Domain.CommandHandlers
{
    public class ProductCommandHandler : CommandHandler,
        INotificationHandler<CreateNewProductCommand>
    {
        private readonly IProductRepository productRepository;
        private readonly IMediatorHandler mediatorHandler;

        public ProductCommandHandler(
            IProductRepository productRepository,
            IUnitOfWork uow, 
            IMediatorHandler bus, 
            INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            this.productRepository = productRepository;
            this.mediatorHandler = bus;
        }

        public void Handle(CreateNewProductCommand message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            var product = new Product(Guid.NewGuid(), message.Name, message.Quantity);

            productRepository.Add(product);
            Commit();
        }
    }
}
