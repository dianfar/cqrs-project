using Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IProductAppService : IDisposable
    {
        void Create(ProductViewModel productViewModel);
    }
}
