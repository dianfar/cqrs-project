using MyApp.Application.Interfaces;
using System;
using MyApp.Application.ViewModels;
using MyApp.Domain.Interfaces;
using AutoMapper;
using MyApp.Infrastructure.Identity.PasswordHasher;
using MyApp.Domain.Core.Bus;
using MyApp.Domain.Commands;
using System.Threading.Tasks;
using MyApp.Domain.Models;

namespace MyApp.Application.Services
{
    public class AccountAppService : IAccountAppService
    {
        private readonly IMapper mapper;
        private readonly IMediatorHandler mediatorHandler;

        public AccountAppService(
            IMapper mapper,
            IMediatorHandler mediatorHandler)
        {
            this.mapper = mapper;
            this.mediatorHandler = mediatorHandler;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<UserViewModel> Login(LoginViewModel viewModel)
        {
            var loginCommand = mapper.Map<AccountLoginQuery>(viewModel);
            var user = await mediatorHandler.GetResult(loginCommand);

            if (user != null)
            {
                return mapper.Map<UserViewModel>(user);
            }

            return null;
        }
    }
}
