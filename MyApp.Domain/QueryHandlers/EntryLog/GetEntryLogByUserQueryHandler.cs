using MediatR;
using MyApp.Domain.CommandHandlers;
using MyApp.Domain.Models;
using MyApp.Domain.Queries;
using System;
using System.Linq;
using MyApp.Domain.Core.Bus;
using MyApp.Domain.Core.Interfaces;
using MyApp.Domain.Core.Notifications;
using MyApp.Domain.Interfaces;

namespace MyApp.Domain.QueryHandlers
{
    public class GetEntryLogByUserQueryHandler : ActionHandler, IRequestHandler<GetEntryLogByUserQuery, IQueryable<EntryLog>>
    {
        private readonly IEntryLogRepository entryLogRepository;

        public GetEntryLogByUserQueryHandler(
            IEntryLogRepository entryLogRepository,
            IUnitOfWork uow, 
            IMediatorHandler bus, 
            INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            this.entryLogRepository = entryLogRepository;
        }

        public IQueryable<EntryLog> Handle(GetEntryLogByUserQuery message)
        {
            return this.entryLogRepository.GetByUser(message.UserId);
        }
    }
}
