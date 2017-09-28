using MyApp.Domain.Commands;
using MyApp.Domain.Core.Bus;
using MyApp.Domain.Core.Notifications;
using MyApp.Domain.Events;
using MyApp.Domain.Interfaces;
using MyApp.Domain.Models;
using MediatR;
using MyApp.Infrastructure.Identity.PasswordHasher;

namespace MyApp.Domain.CommandHandlers
{
    public class AccountCommandHandler : CommandHandler,
                                         IRequestHandler<AccountLoginQuery, User>
    {
        private readonly IUserRepository userRepository;
        private readonly IMediatorHandler mediatorHandler;
        private readonly IPasswordHasher passwordHasher;

        public AccountCommandHandler(IUserRepository userRepository,
                                      IUnitOfWork unitOfWork,
                                      IMediatorHandler mediatorHandler,
                                      IPasswordHasher passwordHasher,
                                      INotificationHandler<DomainNotification> notifications) : base(unitOfWork, mediatorHandler, notifications)
        {
            this.userRepository = userRepository;
            this.mediatorHandler = mediatorHandler;
            this.passwordHasher = passwordHasher;
        }

        public User Handle(AccountLoginQuery message)
        {
            var user = this.userRepository.GetByEmail(message.Email);
            var hashPassword = passwordHasher.HashPassword(message.Password, user.PasswordSalt);
            if (hashPassword.Equals(user.Password))
            {
                return user;
            }

            return null;
        }
    }
}
