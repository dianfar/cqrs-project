using MyApp.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace MyApp.Application.Interfaces
{
    public interface IProductAppService : IDisposable
    {
        IEnumerable<ProductViewModel> GetAll();
        ProductViewModel GetById(Guid id);
        void Create(ProductViewModel productViewModel);
        void Update(ProductViewModel productViewModel);
        void Remove(Guid id);
    }
}
