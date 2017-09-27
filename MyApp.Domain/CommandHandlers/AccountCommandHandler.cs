using MyApp.Domain.Commands;
using MyApp.Domain.Core.Bus;
using MyApp.Domain.Core.Notifications;
using MyApp.Domain.Events;
using MyApp.Domain.Interfaces;
using MyApp.Domain.Models;
using MediatR;
using System;

namespace MyApp.Domain.CommandHandlers
{
    public class AccountCommandHandler : CommandHandler,
                                         IRequestHandler<AccountLoginCommand, User>
    {
        private readonly IUserRepository userRepository;
        private readonly IMediatorHandler mediatorHandler;

        public AccountCommandHandler(IUserRepository userRepository,
                                      IUnitOfWork unitOfWork,
                                      IMediatorHandler mediatorHandler,
                                      INotificationHandler<DomainNotification> notifications) : base(unitOfWork, mediatorHandler, notifications)
        {
            this.userRepository = userRepository;
            this.mediatorHandler = mediatorHandler;
        }

        public User Handle(AccountLoginCommand message)
        {
            throw new NotImplementedException();
        }
    }
}
