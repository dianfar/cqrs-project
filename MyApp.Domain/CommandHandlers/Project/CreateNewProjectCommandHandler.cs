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
    public class CreateNewProjectCommandHandler : ActionHandler, IRequestHandler<CreateNewProjectCommand>
    {
        private readonly IProjectRepository projectRepository;
        private readonly IClientRepository clientRepository;

        public CreateNewProjectCommandHandler(
            IProjectRepository projectRepository,
            IClientRepository clientRepository,
            IUnitOfWork uow, 
            IMediatorHandler bus, 
            INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            this.projectRepository = projectRepository;
            this.clientRepository = clientRepository;
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
    }
}
