using MyApp.Domain.CommandHandlers;
using MyApp.Domain.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using MyApp.Domain.Core.Bus;
using MyApp.Domain.Core.Notifications;
using MyApp.Domain.Interfaces;
using MyApp.Domain.Models;

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
