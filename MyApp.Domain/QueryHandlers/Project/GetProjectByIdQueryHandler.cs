using MediatR;
using MyApp.Domain.CommandHandlers;
using MyApp.Domain.Models;
using MyApp.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using MyApp.Domain.Core.Bus;
using MyApp.Domain.Core.Interfaces;
using MyApp.Domain.Core.Notifications;
using MyApp.Domain.Interfaces;

namespace MyApp.Domain.QueryHandlers
{
    public class GetProjectByIdQueryHandler : ActionHandler, IRequestHandler<GetProjectByIdQuery, Project>
    {
        private readonly IProjectRepository projectRepository;

        public GetProjectByIdQueryHandler(
            IProjectRepository projectRepository,
            IUnitOfWork uow,
            IMediatorHandler bus,
            INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            this.projectRepository = projectRepository;
        }

        public Project Handle(GetProjectByIdQuery message)
        {
            return projectRepository.GetById(message.Id);
        }
    }
}
