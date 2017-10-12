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
    public class GetProjectsByUserQueryHandler : ActionHandler, IRequestHandler<GetProjectsByUserQuery, IQueryable<Project>>
    {
        private readonly IProjectRepository projectRepository;

        public GetProjectsByUserQueryHandler(
            IProjectRepository projectRepository,
            IUnitOfWork uow, 
            IMediatorHandler bus, 
            INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            this.projectRepository = projectRepository;
        }

        public IQueryable<Project> Handle(GetProjectsByUserQuery message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return null;
            }

            return projectRepository.GetProjectsByUser(message.UserId);
        }
    }
}
