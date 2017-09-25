using System;
using MediatR;
using MyApp.Domain.Core.Bus;
using MyApp.Domain.Core.Notifications;
using MyApp.Domain.Interfaces;
using MyApp.Domain.Commands;
using MyApp.Domain.Models;
using MyApp.Infrastructure.Identity.PasswordHasher;

namespace MyApp.Domain.CommandHandlers
{
    public class UserCommandHandler : CommandHandler, 
        INotificationHandler<RegisterNewUserCommand>,
        INotificationHandler<UpdateUserCommand>,
        INotificationHandler<RemoveUserCommand>
    {
        private readonly IRoleRepository roleRepository;
        private readonly IUserRepository userRepository;
        private readonly IMediatorHandler mediatorHandler;
        private readonly IPasswordHasher passwordHasher;

        public UserCommandHandler(
            IRoleRepository roleRepository,
            IUserRepository userRepository,
            IPasswordHasher passwordHasher,
            IUnitOfWork uow, 
            IMediatorHandler bus, 
            INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            this.mediatorHandler = bus;
            this.roleRepository = roleRepository;
            this.userRepository = userRepository;
            this.passwordHasher = passwordHasher;
        }

        public void Handle(RegisterNewUserCommand message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            var role = this.roleRepository.GetById(message.RoleId);
            var user = new User(Guid.NewGuid(), message.Name, true, message.Email, role);
            var hashPassword = passwordHasher.HashPassword(message.Password);
            user.Password = hashPassword;
            user.PasswordSalt = passwordHasher.GetSalt();

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

            var role = this.roleRepository.GetById(message.RoleId);
            var user = this.userRepository.GetById(message.Id);
            user.Name = message.Name;
            user.Active = message.Active;
            user.Email = message.Email;
            user.Role = role;

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
