using MediatR;
using MyApp.Domain.Interfaces;
using MyApp.Domain.Queries;
using System;
using MyApp.Domain.Core.Bus;
using MyApp.Domain.Core.Interfaces;
using MyApp.Domain.Core.Notifications;
using MyApp.Domain.Models;

namespace MyApp.Domain.CommandHandlers
{
    public class RemoveProjectMemberCommandHandler : ActionHandler, IRequestHandler<RemoveProjectMemberCommand>
    {
        private readonly IProjectMemberRepository projectMemberRepository;

        public RemoveProjectMemberCommandHandler(
            IProjectMemberRepository projectMemberRepository,
            IUnitOfWork uow, 
            IMediatorHandler bus, 
            INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            this.projectMemberRepository = projectMemberRepository;
        }

        public void Handle(RemoveProjectMemberCommand message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            projectMemberRepository.Remove(message.Id);
            Commit();
        }
    }
}
