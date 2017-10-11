using MediatR;
using MyApp.Domain.Queries;
using MyApp.Domain.Core.Bus;
using MyApp.Domain.Core.Interfaces;
using MyApp.Domain.Core.Notifications;
using MyApp.Domain.Interfaces;

namespace MyApp.Domain.CommandHandlers
{
    public class RemoveEntryLogCommandHandler : ActionHandler, IRequestHandler<RemoveEntryLogCommand>
    {
        private readonly IEntryLogRepository entryLogRepository;

        public RemoveEntryLogCommandHandler(
            IEntryLogRepository entryLogRepository,
            IUnitOfWork uow, 
            IMediatorHandler bus, 
            INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            this.entryLogRepository = entryLogRepository;
        }

        public void Handle(RemoveEntryLogCommand message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            entryLogRepository.Remove(message.Id);
            Commit();
        }
    }
}
