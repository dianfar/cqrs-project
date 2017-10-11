using MediatR;
using MyApp.Domain.Queries;
using MyApp.Domain.Core.Bus;
using MyApp.Domain.Core.Interfaces;
using MyApp.Domain.Core.Notifications;
using MyApp.Domain.Interfaces;
using MyApp.Domain.Models;

namespace MyApp.Domain.CommandHandlers
{
    public class UpdateEntryLogCommandHandler : ActionHandler, IRequestHandler<UpdateEntryLogCommand>
    {
        private readonly IEntryLogRepository entryLogRepository;
        private readonly IUserRepository userRepository;
        private readonly IProjectRepository projectRepository;

        public UpdateEntryLogCommandHandler(
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

        public void Handle(UpdateEntryLogCommand message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            var user = userRepository.GetById(message.UserId);
            var project = projectRepository.GetById(message.ProjectId);
            var entryLog = new EntryLog(message.Id, message.EntryDate, message.Hours, message.Description);
            entryLog.User = user;
            entryLog.Project = project;

            entryLogRepository.Update(entryLog);
            Commit();
        }
    }
}
