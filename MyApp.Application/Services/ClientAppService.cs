using MyApp.Application.Interfaces;
using MyApp.Application.ViewModels;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MyApp.Domain.Commands;
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
                                  IMediatorHandler bus)
        {
            this.mapper = mapper;
            this.clientRepository = clientRepository;
            mediatorHandler = bus;
        }

        public IEnumerable<ClientViewModel> GetAll()
        {
            return clientRepository.GetAll().ProjectTo<ClientViewModel>();
        }

        public ClientViewModel GetById(Guid id)
        {
            return mapper.Map<ClientViewModel>(clientRepository.GetById(id));
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
