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
    public class AddProjectMemberCommandHandler : ActionHandler, IRequestHandler<AddProjectMemberCommand>
    {
        private readonly IProjectMemberRepository projectMemberRepository;
        private readonly IUserRepository userRepository;
        private readonly IProjectRepository projectRepository;

        public AddProjectMemberCommandHandler(
            IProjectMemberRepository projectMemberRepository,
            IUserRepository userRepository,
            IProjectRepository projectRepository,
            IUnitOfWork uow, 
            IMediatorHandler bus, 
            INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            this.projectMemberRepository = projectMemberRepository;
            this.userRepository = userRepository;
            this.projectRepository = projectRepository;
        }

        public void Handle(AddProjectMemberCommand message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            var member = new ProjectMember(Guid.NewGuid());
            member.User = userRepository.GetById(message.UserId);
            member.Project = projectRepository.GetById(message.ProjectId);

            projectMemberRepository.Add(member);
            Commit();
        }
    }
}
