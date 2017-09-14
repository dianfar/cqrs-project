using MediatR;
using MyApp.Domain.Core.Bus;
using MyApp.Domain.Core.Notifications;
using MyApp.Domain.Interfaces;

namespace MyApp.Domain.CommandHandlers
{
    public class ProjectMemberCommandHandler : CommandHandler
    {
        public ProjectMemberCommandHandler(IUnitOfWork uow, IMediatorHandler bus, INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
        }
    }
}
