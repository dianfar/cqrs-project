using Application.Interfaces;
using System;
using Application.ViewModels;
using Domain.Core.Bus;
using AutoMapper;
using Domain.Interfaces;
using Domain.Commands;

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
    }
}
