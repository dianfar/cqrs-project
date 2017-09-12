using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using MyApp.Domain.Core.Bus;
using MyApp.Domain.Core.Notifications;
using MyApp.Domain.Interfaces;
using MyApp.Domain.Commands;
using MyApp.Domain.Models;

namespace MyApp.Domain.CommandHandlers
{
    public class UserCommandHandler : CommandHandler, INotificationHandler<RegisterNewUserCommand>
    {
        private readonly IUserRepository userRepository;
        private readonly IMediatorHandler mediatorHandler;

        public UserCommandHandler(
            IUserRepository userRepository,
            IUnitOfWork uow, 
            IMediatorHandler bus, 
            INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            this.mediatorHandler = bus;
            this.userRepository = userRepository;
        }

        public void Handle(RegisterNewUserCommand message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            var user = new User(message.Name, true, message.Email);

            this.userRepository.Add(user);
        }
    }
}
