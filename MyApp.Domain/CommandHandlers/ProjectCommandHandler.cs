using MyApp.Domain.Queries;
using MediatR;
using System;
using MyApp.Domain.Core.Bus;
using MyApp.Domain.Core.Notifications;
using MyApp.Domain.Interfaces;
using MyApp.Domain.Models;
using MyApp.Domain.Core.Interfaces;

namespace MyApp.Domain.CommandHandlers
{
    public class ProjectCommandHandler : ActionHandler,
        IRequestHandler<CreateNewProjectCommand>,
        IRequestHandler<UpdateProjectCommand>,
        IRequestHandler<RemoveProjectCommand>
    {
        private readonly IProjectRepository projectRepository;
        private readonly IClientRepository clientRepository;
        private readonly IMediatorHandler mediatorHandler;

        public ProjectCommandHandler(
            IProjectRepository projectRepository,
            IClientRepository clientRepository,
            IUnitOfWork uow, 
            IMediatorHandler bus, 
            INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            this.projectRepository = projectRepository;
            this.clientRepository = clientRepository;
            this.mediatorHandler = bus;
        }

        public void Handle(CreateNewProjectCommand message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            var client = clientRepository.GetById(message.ClientId);
            var product = new Project(Guid.NewGuid(), message.Name, message.Description, message.CompletionDate, true, client);
            
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

            var client = clientRepository.GetById(message.ClientId);
            var product = new Project(message.Id, message.Name, message.Description, message.CompletionDate, message.Active, client);

            projectRepository.Update(product);
            Commit();
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
