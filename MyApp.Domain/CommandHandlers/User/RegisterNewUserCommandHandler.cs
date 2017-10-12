using MediatR;
using MyApp.Domain.Commands;
using System;
using MyApp.Domain.Core.Bus;
using MyApp.Domain.Core.Interfaces;
using MyApp.Domain.Core.Notifications;
using MyApp.Domain.Interfaces;
using MyApp.Infrastructure.Identity.PasswordHasher;
using MyApp.Domain.Models;
using MyApp.Domain.Events;

namespace MyApp.Domain.CommandHandlers
{
    public class RegisterNewUserCommandHandler : ActionHandler, IRequestHandler<RegisterNewUserCommand>
    {
        private readonly IRoleRepository roleRepository;
        private readonly IUserRepository userRepository;
        private readonly IPasswordHasher passwordHasher;
        private readonly IMediatorHandler mediatorHandler;

        public RegisterNewUserCommandHandler(
            IRoleRepository roleRepository,
            IUserRepository userRepository,
            IPasswordHasher passwordHasher,
            IUnitOfWork uow, 
            IMediatorHandler bus, 
            INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            this.roleRepository = roleRepository;
            this.userRepository = userRepository;
            this.passwordHasher = passwordHasher;
            this.mediatorHandler = bus;
        }

        public void Handle(RegisterNewUserCommand message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            if (userRepository.GetByEmail(message.Email) != null)
            {
                mediatorHandler.RaiseEvent(new DomainNotification(message.MessageType, "The user e-mail has already been taken."));
                return;
            }

            var role = this.roleRepository.GetById(message.RoleId);
            var user = new User(Guid.NewGuid(), message.Name, true, message.Email, role);
            var hashPassword = passwordHasher.HashPassword(message.Password);
            user.Password = hashPassword;
            user.PasswordSalt = passwordHasher.GetSalt();

            this.userRepository.Add(user);
            if (this.Commit())
            {
                mediatorHandler.RaiseEvent(new ClientRegisteredEvent(user.Id, user.Name, user.Email));
            }
        }
    }
}
