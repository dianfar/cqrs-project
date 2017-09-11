using MyApp.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using MyApp.Application.ViewModels;
using MyApp.Domain.Interfaces;
using MyApp.Domain.Core.Bus;
using AutoMapper;
using MyApp.Domain.Commands;

namespace MyApp.Application.Services
{
    public class UserAppService : IUserAppService
    {
        private readonly IMapper mapper;
        private readonly IUserRepository userRepository;
        private readonly IMediatorHandler mediatorHandler;

        public UserAppService(IMapper mapper,
                                  IUserRepository userRepository,
                                  IMediatorHandler bus)
        {
            this.mapper = mapper;
            this.userRepository = userRepository;
            this.mediatorHandler = bus;
        }

        public void Create(UserViewModel userViewModel)
        {
            var registerCommand = mapper.Map<RegisterNewUserCommand>(userViewModel);
            mediatorHandler.SendCommand(registerCommand);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public UserViewModel GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(UserViewModel userViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
