using MediatR;
using MyApp.Domain.Commands;
using MyApp.Domain.Core.Bus;
using MyApp.Domain.Core.Interfaces;
using MyApp.Domain.Core.Notifications;
using MyApp.Domain.Interfaces;
using MyApp.Domain.Events;

namespace MyApp.Domain.CommandHandlers
{
    public class UpdateUserCommandHandler : ActionHandler, IRequestHandler<UpdateUserCommand>
    {
        private readonly IRoleRepository roleRepository;
        private readonly IUserRepository userRepository;
        private readonly IMediatorHandler mediatorHandler;

        public UpdateUserCommandHandler(
            IRoleRepository roleRepository,
            IUserRepository userRepository,
            IUnitOfWork uow,
            IMediatorHandler bus,
            INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            this.roleRepository = roleRepository;
            this.userRepository = userRepository;
            this.mediatorHandler = bus;
        }

        public void Handle(UpdateUserCommand message)
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
            var user = this.userRepository.GetById(message.Id);
            user.Name = message.Name;
            user.Active = message.Active;
            user.Email = message.Email;
            user.Role = role;

            userRepository.Update(user);
            if (this.Commit())
            {
                mediatorHandler.RaiseEvent(new ClientUpdatedEvent(user.Id, user.Name, user.Email));
            }
        }
    }
}
