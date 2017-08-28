using MyApp.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace MyApp.Application.Interfaces
{
    public interface IProductAppService : IDisposable
    {
        IEnumerable<ProductViewModel> GetAll();
        void Create(ProductViewModel productViewModel);
    }
}
