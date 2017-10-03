using MediatR;
using MyApp.Domain.CommandHandlers;
using MyApp.Domain.Models;
using MyApp.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using MyApp.Domain.Core.Bus;
using MyApp.Domain.Core.Interfaces;
using MyApp.Domain.Core.Notifications;

namespace MyApp.Domain.QueryHandlers
{
    public class GetUserByIdQueryHandler : ActionHandler, IRequestHandler<GetUserByIdQuery, User>
    {
        public GetUserByIdQueryHandler(IUnitOfWork uow, IMediatorHandler bus, INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
        }

        public User Handle(GetUserByIdQuery message)
        {
            throw new NotImplementedException();
        }
    }
}
