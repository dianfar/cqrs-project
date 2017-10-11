using MediatR;
using MyApp.Domain.CommandHandlers;
using MyApp.Domain.Models;
using MyApp.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyApp.Domain.Core.Bus;
using MyApp.Domain.Core.Interfaces;
using MyApp.Domain.Core.Notifications;
using MyApp.Domain.Interfaces;

namespace MyApp.Domain.QueryHandlers
{
    public class GetAllUserQueryHandler : ActionHandler, IRequestHandler<GetAllUserQuery, IQueryable<User>>
    {
        private readonly IUserRepository userRepository;

        public GetAllUserQueryHandler(
            IUserRepository userRepository,
            IUnitOfWork uow, 
            IMediatorHandler bus, 
            INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            this.userRepository = userRepository;
        }

        public IQueryable<User> Handle(GetAllUserQuery message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return null;
            }

            return userRepository.GetAll();
        }
    }
}
