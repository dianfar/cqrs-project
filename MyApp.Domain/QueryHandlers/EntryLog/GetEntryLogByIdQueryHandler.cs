using MediatR;
using MyApp.Domain.CommandHandlers;
using MyApp.Domain.Models;
using MyApp.Domain.Queries;
using MyApp.Domain.Core.Bus;
using MyApp.Domain.Core.Interfaces;
using MyApp.Domain.Core.Notifications;
using MyApp.Domain.Interfaces;

namespace MyApp.Domain.QueryHandlers
{
    public class GetEntryLogByIdQueryHandler : ActionHandler, IRequestHandler<GetEntryLogByIdQuery, EntryLog>
    {
        private readonly IEntryLogRepository entryLogRepository;

        public GetEntryLogByIdQueryHandler(
            IEntryLogRepository entryLogRepository,
            IUnitOfWork uow, 
            IMediatorHandler bus, 
            INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            this.entryLogRepository = entryLogRepository;
        }

        public EntryLog Handle(GetEntryLogByIdQuery message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return null;
            }

            return this.entryLogRepository.GetById(message.Id);
        }
    }
}
