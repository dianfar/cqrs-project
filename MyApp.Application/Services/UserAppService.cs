using MyApp.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using MyApp.Application.ViewModels;
using MyApp.Domain.Interfaces;
using MyApp.Domain.Core.Bus;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MyApp.Domain.Commands;

namespace MyApp.Application.Services
{
    public class UserAppService : IUserAppService
    {
        private readonly IMapper mapper;
        private readonly IUserRepository userRepository;
        private readonly IRoleRepository roleRepository;
        private readonly IMediatorHandler mediatorHandler;

        public UserAppService(IMapper mapper,
                                  IUserRepository userRepository,
                                  IRoleRepository roleRepository,
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
            GC.SuppressFinalize(this);
        }

        public IEnumerable<UserViewModel> GetAll()
        {
            return userRepository.GetAll().ProjectTo<UserViewModel>();
        }

        public UserViewModel GetById(Guid id)
        {
            return mapper.Map<UserViewModel>(userRepository.GetById(id));
        }

        public RegisterNewUserViewModel GetRegisterNewUserData()
        {
            var roles = this.roleRepository.GetAll().ProjectTo<RoleViewModel>();
            return new RegisterNewUserViewModel()
            {
                Roles = roles
            };
        }

        public void Remove(Guid id)
        {
            var removeCommand = new RemoveUserCommand(id);
            mediatorHandler.SendCommand(removeCommand);
        }

        public void Update(UserViewModel userViewModel)
        {
            var updateCommand = mapper.Map<UpdateUserCommand>(userViewModel);
            mediatorHandler.SendCommand(updateCommand);
        }
    }
}
