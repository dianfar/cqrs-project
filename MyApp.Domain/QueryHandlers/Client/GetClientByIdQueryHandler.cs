using MediatR;
using MyApp.Domain.CommandHandlers;
using MyApp.Domain.Models;
using MyApp.Domain.Queries;
using System;
using MyApp.Domain.Core.Bus;
using MyApp.Domain.Core.Interfaces;
using MyApp.Domain.Core.Notifications;
using MyApp.Domain.Interfaces;

namespace MyApp.Domain.QueryHandlers
{
    public class GetClientByIdQueryHandler : ActionHandler,
                                         IRequestHandler<GetClientByIdQuery, Client>
    {
        private readonly IClientRepository clientRepository;

        public GetClientByIdQueryHandler(
            IClientRepository clientRepository,
            IUnitOfWork uow, 
            IMediatorHandler bus, 
            INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            this.clientRepository = clientRepository;
        }

        public Client Handle(GetClientByIdQuery message)
        {
            return clientRepository.GetById(message.Id);
        }
    }
}
