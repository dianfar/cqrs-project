using MyApp.Application.Interfaces;
using MyApp.Application.ViewModels;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MyApp.Domain.Queries;
using MyApp.Domain.Core.Bus;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyApp.Domain.Commands;

namespace MyApp.Application.Services
{
    public class ClientAppService : IClientAppService
    {
        private readonly IMapper mapper;
        private readonly IMediatorHandler mediatorHandler;

        public ClientAppService(IMapper mapper,
                                  IMediatorHandler mediatorHandler)
        {
            this.mapper = mapper;
            this.mediatorHandler = mediatorHandler;
        }

        public async Task<IEnumerable<ClientViewModel>> GetAll()
        {
            var clients = await mediatorHandler.GetResult(new GetAllClientQuery());
            return clients.ProjectTo<ClientViewModel>();
        }

        public async Task<ClientViewModel> GetById(Guid id)
        {
            var client = await mediatorHandler.GetResult(new GetClientByIdQuery(id));
            return mapper.Map<ClientViewModel>(client);
        }

        public void Register(ClientViewModel customerViewModel)
        {
            var registerCommand = mapper.Map<RegisterNewClientCommand>(customerViewModel);
            mediatorHandler.SendCommand(registerCommand);
        }

        public void Update(ClientViewModel customerViewModel)
        {
            var updateCommand = mapper.Map<UpdateClientCommand>(customerViewModel);
            mediatorHandler.SendCommand(updateCommand);
        }

        public void Remove(Guid id)
        {
            var removeCommand = new RemoveClientCommand(id);
            mediatorHandler.SendCommand(removeCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
