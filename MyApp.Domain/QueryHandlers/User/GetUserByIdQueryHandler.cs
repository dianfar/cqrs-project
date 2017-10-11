using MediatR;
using MyApp.Domain.CommandHandlers;
using MyApp.Domain.Models;
using MyApp.Domain.Queries;
using MyApp.Domain.Core.Bus;
using MyApp.Domain.Core.Interfaces;
using MyApp.Domain.Core.Notifications;
using MyApp.Domain.Interfaces;

namespace MyApp.Domain.QueryHandlers
{
    public class GetUserByIdQueryHandler : ActionHandler, IRequestHandler<GetUserByIdQuery, User>
    {
        private readonly IUserRepository userRepository;

        public GetUserByIdQueryHandler(
            IUserRepository userRepository,
            IUnitOfWork uow, 
            IMediatorHandler bus, 
            INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            this.userRepository = userRepository;
        }

        public User Handle(GetUserByIdQuery message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return null;
            }

            return userRepository.GetById(message.Id);
        }
    }
}
