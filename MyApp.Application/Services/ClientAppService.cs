using MyApp.Application.Interfaces;
using MyApp.Application.ViewModels;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MyApp.Domain.Queries;
using MyApp.Domain.Core.Bus;
using MyApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Services
{
    public class ClientAppService : IClientAppService
    {
        private readonly IMapper mapper;
        private readonly IClientRepository clientRepository;
        private readonly IMediatorHandler mediatorHandler;

        public ClientAppService(IMapper mapper,
                                  IClientRepository clientRepository,
                                  IMediatorHandler mediatorHandler)
        {
            this.mapper = mapper;
            this.clientRepository = clientRepository;
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
