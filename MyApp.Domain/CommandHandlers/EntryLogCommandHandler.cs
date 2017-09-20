using System;
using MediatR;
using MyApp.Domain.Core.Bus;
using MyApp.Domain.Core.Notifications;
using MyApp.Domain.Interfaces;
using MyApp.Domain.Commands;
using MyApp.Domain.Models;

namespace MyApp.Domain.CommandHandlers
{
    public class EntryLogCommandHandler : CommandHandler,
            INotificationHandler<AddEntryLogCommand>,
            INotificationHandler<UpdateEntryLogCommand>,
            INotificationHandler<RemoveEntryLogCommand>
    {
        private readonly IEntryLogRepository entryLogRepository;
        private readonly IUserRepository userRepository;
        private readonly IProjectRepository projectRepository;
        private readonly IMediatorHandler mediatorHandler;

        public EntryLogCommandHandler(
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
            this.mediatorHandler = bus;
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

        public void Handle(UpdateEntryLogCommand notification)
        {
            throw new NotImplementedException();
        }

        public void Handle(RemoveEntryLogCommand notification)
        {
            throw new NotImplementedException();
        }
    }
}
