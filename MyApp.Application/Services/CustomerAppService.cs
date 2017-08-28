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
    public class CustomerAppService : ICustomerAppService
    {
        private readonly IMapper mapper;
        private readonly ICustomerRepository customerRepository;
        private readonly IMediatorHandler mediatorHandler;

        public CustomerAppService(IMapper mapper,
                                  ICustomerRepository customerRepository,
                                  IMediatorHandler bus)
        {
            this.mapper = mapper;
            this.customerRepository = customerRepository;
            mediatorHandler = bus;
        }

        public IEnumerable<CustomerViewModel> GetAll()
        {
            return customerRepository.GetAll().ProjectTo<CustomerViewModel>();
        }

        public CustomerViewModel GetById(Guid id)
        {
            return mapper.Map<CustomerViewModel>(customerRepository.GetById(id));
        }

        public void Register(CustomerViewModel customerViewModel)
        {
            var registerCommand = mapper.Map<RegisterNewCustomerCommand>(customerViewModel);
            mediatorHandler.SendCommand(registerCommand);
        }

        public void Update(CustomerViewModel customerViewModel)
        {
            var updateCommand = mapper.Map<UpdateCustomerCommand>(customerViewModel);
            mediatorHandler.SendCommand(updateCommand);
        }

        public void Remove(Guid id)
        {
            var removeCommand = new RemoveCustomerCommand(id);
            mediatorHandler.SendCommand(removeCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
