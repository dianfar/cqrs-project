using MediatR;
using MyApp.Domain.Queries;
using MyApp.Domain.Core.Bus;
using MyApp.Domain.Core.Interfaces;
using MyApp.Domain.Core.Notifications;
using MyApp.Domain.Interfaces;
using MyApp.Domain.Events;

namespace MyApp.Domain.CommandHandlers
{
    public class RemoveUserCommandHandler : ActionHandler, IRequestHandler<RemoveUserCommand>
    {
        private readonly IUserRepository userRepository;
        private readonly IMediatorHandler mediatorHandler;

        public RemoveUserCommandHandler(
            IUserRepository userRepository,
            IUnitOfWork uow, 
            IMediatorHandler bus, 
            INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            this.mediatorHandler = bus;
            this.userRepository = userRepository;
        }

        public void Handle(RemoveUserCommand message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            userRepository.Remove(message.Id);
            if (this.Commit())
            {
                mediatorHandler.RaiseEvent(new ClientRemovedEvent(message.Id));
            }
        }
    }
}
