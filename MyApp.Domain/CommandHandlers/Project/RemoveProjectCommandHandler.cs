using MediatR;
using MyApp.Domain.Interfaces;
using MyApp.Domain.Queries;
using MyApp.Domain.Core.Bus;
using MyApp.Domain.Core.Interfaces;
using MyApp.Domain.Core.Notifications;

namespace MyApp.Domain.CommandHandlers
{
    public class RemoveProjectCommandHandler : ActionHandler, IRequestHandler<RemoveProjectCommand>
    {
        private readonly IProjectRepository projectRepository;

        public RemoveProjectCommandHandler(
            IProjectRepository projectRepository,
            IUnitOfWork uow, 
            IMediatorHandler bus, 
            INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            this.projectRepository = projectRepository;
        }

        public void Handle(RemoveProjectCommand message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            projectRepository.Remove(message.Id);
            Commit();
        }
    }
}
