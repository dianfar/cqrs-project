using MyApp.Domain.Core.Bus;
using MyApp.Domain.Core.Commands;
using MyApp.Domain.Core.Notifications;
using MyApp.Domain.Interfaces;
using MediatR;

namespace MyApp.Domain.CommandHandlers
{
    public class CommandHandler
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMediatorHandler mediatorHandler;
        private readonly DomainNotificationHandler domainNotificationHandler;

        public CommandHandler(IUnitOfWork uow, IMediatorHandler bus, INotificationHandler<DomainNotification> notifications)
        {
            unitOfWork = uow;
            domainNotificationHandler = (DomainNotificationHandler)notifications;
            mediatorHandler = bus;
        }

        protected void NotifyValidationErrors(Command message)
        {
            foreach (var error in message.ValidationResult.Errors)
            {
                mediatorHandler.RaiseEvent(new DomainNotification(message.MessageType, error.ErrorMessage));
            }
        }

        public bool Commit()
        {
            if (domainNotificationHandler.HasNotifications()) return false;
            var commandResponse = unitOfWork.Commit();
            if (commandResponse.Success) return true;

            mediatorHandler.RaiseEvent(new DomainNotification("Commit", "We had a problem during saving your data."));
            return false;
        }
    }
}
