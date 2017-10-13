using System.Collections.Generic;
using System.Threading.Tasks;
using MyApp.Application.Interfaces;
using MyApp.Application.ViewModels;
using AutoMapper;
using MyApp.Domain.Core.Bus;
using MyApp.Domain.Queries;
using AutoMapper.QueryableExtensions;

namespace MyApp.Application.Services
{
    public class RoleAppService : IRoleAppService
    {
        private readonly IMapper mapper;
        private readonly IMediatorHandler mediatorHandler;

        public RoleAppService(
            IMapper mapper,
            IMediatorHandler bus)
        {
            this.mapper = mapper;
            this.mediatorHandler = bus;
        }

        public async Task<IEnumerable<RoleViewModel>> GetAll()
        {
            var roles = await mediatorHandler.GetResult(new GetAllRoleQuery());
            return roles.ProjectTo<RoleViewModel>();
        }
    }
}
