using MediatR;
using MyApp.Domain.CommandHandlers;
using MyApp.Domain.Models;
using MyApp.Domain.Queries;
using System.Linq;
using MyApp.Domain.Core.Bus;
using MyApp.Domain.Core.Interfaces;
using MyApp.Domain.Core.Notifications;
using MyApp.Domain.Interfaces;

namespace MyApp.Domain.QueryHandlers
{
    public class GetAllRoleQueryHandler : ActionHandler, IRequestHandler<GetAllRoleQuery, IQueryable<Role>>
    {
        private readonly IRoleRepository roleRepository;

        public GetAllRoleQueryHandler(
            IRoleRepository roleRepository,
            IUnitOfWork uow, 
            IMediatorHandler bus, 
            INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            this.roleRepository = roleRepository;
        }

        public IQueryable<Role> Handle(GetAllRoleQuery message)
        {
            return roleRepository.GetAll();
        }
    }
}
