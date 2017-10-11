using MediatR;
using MyApp.Domain.Queries;
using System;
using MyApp.Domain.Core.Bus;
using MyApp.Domain.Core.Interfaces;
using MyApp.Domain.Core.Notifications;
using MyApp.Domain.Interfaces;
using MyApp.Domain.Models;

namespace MyApp.Domain.CommandHandlers
{
    public class AddEntryLogCommandHandler : ActionHandler, IRequestHandler<AddEntryLogCommand>
    {
        private readonly IEntryLogRepository entryLogRepository;
        private readonly IUserRepository userRepository;
        private readonly IProjectRepository projectRepository;

        public AddEntryLogCommandHandler(
            IEntryLogRepository entryLogRepository,
            IUserRepository userRepository,
            IProjectRepository projectRepository,
            IUnitOfWork uow, 
            IMediatorHandler bus, 
            INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            this.entryLogRepository = entryLogRepository;
            this.userRepository = userRepository;
            this.projectRepository = projectRepository;
        }

        public void Handle(AddEntryLogCommand message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            var user = userRepository.GetById(message.UserId);
            var project = projectRepository.GetById(message.ProjectId);
            var entryLog = new EntryLog(Guid.NewGuid(), message.EntryDate, message.Hours, message.Description);
            entryLog.User = user;
            entryLog.Project = project;

            entryLogRepository.Add(entryLog);
            Commit();
        }
    }
}
