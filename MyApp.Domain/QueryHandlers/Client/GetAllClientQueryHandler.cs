using MediatR;
using MyApp.Domain.Models;
using MyApp.Domain.CommandHandlers;
using MyApp.Domain.Queries;
using System.Linq;
using MyApp.Domain.Core.Bus;
using MyApp.Domain.Core.Interfaces;
using MyApp.Domain.Core.Notifications;
using MyApp.Domain.Interfaces;

namespace MyApp.Domain.QueryHandlers
{
    public class GetAllClientQueryHandler : ActionHandler, IRequestHandler<GetAllClientQuery, IQueryable<Client>>
    {
        private readonly IClientRepository clientRepository;

        public GetAllClientQueryHandler(
            IClientRepository clientRepository,
            IUnitOfWork uow, 
            IMediatorHandler bus, 
            INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            this.clientRepository = clientRepository;
        }

        public IQueryable<Client> Handle(GetAllClientQuery message)
        {
            return clientRepository.GetAll();
        }
    }
}
