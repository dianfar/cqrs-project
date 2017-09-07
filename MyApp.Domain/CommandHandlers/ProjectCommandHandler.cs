using MyApp.Domain.Commands;
using MediatR;
using System;
using MyApp.Domain.Core.Bus;
using MyApp.Domain.Core.Notifications;
using MyApp.Domain.Interfaces;
using MyApp.Domain.Models;

namespace MyApp.Domain.CommandHandlers
{
    public class ProjectCommandHandler : CommandHandler,
        INotificationHandler<CreateNewProjectCommand>,
        INotificationHandler<UpdateProjectCommand>,
        INotificationHandler<RemoveProductCommand>
    {
        private readonly IProjectRepository projectRepository;
        private readonly IMediatorHandler mediatorHandler;

        public ProjectCommandHandler(
            IProjectRepository productRepository,
            IUnitOfWork uow, 
            IMediatorHandler bus, 
            INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            this.projectRepository = productRepository;
            this.mediatorHandler = bus;
        }

        public void Handle(CreateNewProjectCommand message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            var product = new Project(Guid.NewGuid(), message.Name, message.Description, message.CompletionDate, true);

            projectRepository.Add(product);
            Commit();
        }

        public void Handle(UpdateProjectCommand message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            var product = new Project(message.Id, message.Name, message.Description, message.CompletionDate, message.Active);
            projectRepository.Update(product);
            Commit();
        }

        public void Handle(RemoveProductCommand message)
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
