using MyApp.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using MyApp.Application.ViewModels;
using MyApp.Domain.Interfaces;
using AutoMapper;
using MyApp.Infrastructure.Identity.PasswordHasher;

namespace MyApp.Application.Services
{
    public class AccountAppService : IAccountAppService
    {
        private readonly IMapper mapper;
        private readonly IUserRepository userRepository;
        private readonly IPasswordHasher passwordHasher;

        public AccountAppService(
            IMapper mapper,
            IUserRepository userRepository,
            IPasswordHasher passwordHasher)
        {
            this.mapper = mapper;
            this.userRepository = userRepository;
            this.passwordHasher = passwordHasher;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public UserViewModel Login(LoginViewModel viewModel)
        {
            var user = this.userRepository.GetByEmail(viewModel.Email);
            var hashPassword = passwordHasher.HashPassword(viewModel.Password, user.PasswordSalt);
            if (hashPassword.Equals(user.Password))
            {
                return mapper.Map<UserViewModel>(user);
            }

            return null;
        }
    }
}
