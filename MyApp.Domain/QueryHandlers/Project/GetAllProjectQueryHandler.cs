using MediatR;
using MyApp.Domain.CommandHandlers;
using MyApp.Domain.Models;
using MyApp.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyApp.Domain.Core.Bus;
using MyApp.Domain.Core.Interfaces;
using MyApp.Domain.Core.Notifications;
using MyApp.Domain.Interfaces;

namespace MyApp.Domain.QueryHandlers
{
    public class GetAllProjectQueryHandler : ActionHandler, IRequestHandler<GetAllProjectQuery, IQueryable<Project>>
    {
        private readonly IProjectRepository projectRepository;

        public GetAllProjectQueryHandler(
            IProjectRepository projectRepository,
            IUnitOfWork uow, 
            IMediatorHandler bus, 
            INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            this.projectRepository = projectRepository;
        }

        public IQueryable<Project> Handle(GetAllProjectQuery message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return null;
            }

            return projectRepository.GetAll();
        }
    }
}
