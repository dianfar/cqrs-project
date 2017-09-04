using MyApp.Application.Interfaces;
using System;
using MyApp.Application.ViewModels;
using MyApp.Domain.Core.Bus;
using AutoMapper;
using MyApp.Domain.Interfaces;
using MyApp.Domain.Commands;
using System.Collections.Generic;
using AutoMapper.QueryableExtensions;

namespace MyApp.Application.Services
{
    public class ProductAppService : IProductAppService
    {
        private readonly IMapper mapper;
        private readonly IProductRepository productRepository;
        private readonly IMediatorHandler mediatorHandler;

        public ProductAppService(IMapper mapper,
                                  IProductRepository productRepository,
                                  IMediatorHandler bus)
        {
            this.mapper = mapper;
            this.productRepository = productRepository;
            mediatorHandler = bus;
        }

        public void Create(ProductViewModel productViewModel)
        {
            var createCommand = mapper.Map<CreateNewProductCommand>(productViewModel);
            mediatorHandler.SendCommand(createCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<ProductViewModel> GetAll()
        {
            return productRepository.GetAll().ProjectTo<ProductViewModel>();
        }

        public ProductViewModel GetById(Guid id)
        {
            return mapper.Map<ProductViewModel>(productRepository.GetById(id));
        }

        public void Remove(Guid id)
        {
            var removeCommand = new RemoveProductCommand(id);
            mediatorHandler.SendCommand(removeCommand);
        }

        public void Update(ProductViewModel productViewModel)
        {
            var updateCommand = mapper.Map<UpdateProductCommand>(productViewModel);
            mediatorHandler.SendCommand(updateCommand);
        }
    }
}
