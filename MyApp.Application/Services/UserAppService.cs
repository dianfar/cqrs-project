using MyApp.Application.Interfaces;
using System;
using System.Collections.Generic;
using MyApp.Application.ViewModels;
using MyApp.Domain.Core.Bus;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MyApp.Domain.Queries;
using System.Threading.Tasks;

namespace MyApp.Application.Services
{
    public class UserAppService : IUserAppService
    {
        private readonly IMapper mapper;
        private readonly IMediatorHandler mediatorHandler;

        public UserAppService(
            IMapper mapper,
            IMediatorHandler bus)
        {
            this.mapper = mapper;
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

        public async Task<IEnumerable<UserViewModel>> GetAll()
        {
            var users = await mediatorHandler.GetResult(new GetAllUserQuery());
            return users.ProjectTo<UserViewModel>();
        }

        public async Task<UserViewModel> GetById(Guid id)
        {
            var user = await mediatorHandler.GetResult(new GetUserByIdQuery(id));
            return mapper.Map<UserViewModel>(user);
        }

        public async Task<RegisterNewUserViewModel> GetRegisterNewUserData()
        {
            var roles = await mediatorHandler.GetResult(new GetAllRoleQuery());
            return new RegisterNewUserViewModel()
            {
                Roles = roles.ProjectTo<RoleViewModel>()
            };
        }

        public async Task<UpdateUserViewModel> GetUpdateUserData(Guid id)
        {
            var roles = await mediatorHandler.GetResult(new GetAllRoleQuery());
            var user = await mediatorHandler.GetResult(new GetUserByIdQuery(id));
            var result = mapper.Map<UpdateUserViewModel>(user);
            result.Roles = roles.ProjectTo<RoleViewModel>();

            return result;
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
