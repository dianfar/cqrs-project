using System;
using MediatR;
using MyApp.Domain.Commands;
using MyApp.Domain.Core.Bus;
using MyApp.Domain.Core.Notifications;
using MyApp.Domain.Interfaces;
using MyApp.Domain.Models;

namespace MyApp.Domain.CommandHandlers
{
    public class ProjectMemberCommandHandler : CommandHandler,
        INotificationHandler<AddProjectMemberCommand>,
        INotificationHandler<RemoveProjectMemberCommand>
    {
        private readonly IProjectMemberRepository projectMemberRepository;
        private readonly IUserRepository userRepository;
        private readonly IProjectRepository projectRepository;

        public ProjectMemberCommandHandler(IUnitOfWork uow, 
            IMediatorHandler bus,
            IProjectMemberRepository projectMemberRepository,
            IUserRepository userRepository,
            IProjectRepository projectRepository,
            INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            this.projectMemberRepository = projectMemberRepository;
            this.userRepository = userRepository;
            this.projectRepository = projectRepository;
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
