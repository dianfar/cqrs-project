using System;
using MediatR;
using MyApp.Domain.Core.Bus;
using MyApp.Domain.Core.Notifications;
using MyApp.Domain.Interfaces;
using MyApp.Domain.Commands;
using MyApp.Domain.Models;

namespace MyApp.Domain.CommandHandlers
{
    public class UserCommandHandler : CommandHandler, 
        INotificationHandler<RegisterNewUserCommand>,
        INotificationHandler<UpdateUserCommand>,
        INotificationHandler<RemoveUserCommand>
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

            var user = new User(Guid.NewGuid(), message.Name, true, message.Email);

            this.userRepository.Add(user);
            this.Commit();
        }

        public void Handle(UpdateUserCommand message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            var user = new User(message.Id, message.Name, message.Active, message.Email);
            userRepository.Update(user);
            this.Commit();
        }

        public void Handle(RemoveUserCommand message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            userRepository.Remove(message.Id);
            this.Commit();
        }
    }
}
