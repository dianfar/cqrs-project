using System;
using MediatR;
using MyApp.Domain.Core.Bus;
using MyApp.Domain.Core.Notifications;
using MyApp.Domain.Interfaces;
using MyApp.Domain.Commands;

namespace MyApp.Domain.CommandHandlers
{
    public class EntryLogCommandHandler : CommandHandler,
            INotificationHandler<AddEntryLogCommand>,
            INotificationHandler<UpdateEntryLogCommand>,
            INotificationHandler<RemoveEntryLogCommand>
    {
        private readonly IEntryLogRepository entryLogRepository;
        private readonly IMediatorHandler mediatorHandler;

        public EntryLogCommandHandler(
            IEntryLogRepository entryLogRepository,
            IUnitOfWork uow, 
            IMediatorHandler bus, 
            INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
        }

        public void Handle(AddEntryLogCommand notification)
        {
            throw new NotImplementedException();
        }

        public void Handle(UpdateEntryLogCommand notification)
        {
            throw new NotImplementedException();
        }

        public void Handle(RemoveEntryLogCommand notification)
        {
            throw new NotImplementedException();
        }
    }
}
