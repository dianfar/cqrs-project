using MyApp.Domain.Interfaces;
using MyApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Domain.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> GetProductsByQuantity(int quantity);
    }
}
