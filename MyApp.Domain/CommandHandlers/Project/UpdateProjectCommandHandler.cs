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
    public class UpdateProjectCommandHandler : ActionHandler, IRequestHandler<UpdateProjectCommand>
    {
        private readonly IProjectRepository projectRepository;
        private readonly IClientRepository clientRepository;

        public UpdateProjectCommandHandler(
            IProjectRepository projectRepository,
            IClientRepository clientRepository,
            IUnitOfWork uow,
            IMediatorHandler bus,
            INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            this.projectRepository = projectRepository;
            this.clientRepository = clientRepository;
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
    }
}
