using MyApp.Domain.Interfaces;
using MyApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyApp.Infrastructure.Data.Context;

namespace MyApp.Infrastructure.Data.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(MyAppContext context) : base(context)
        {
        }

        public IEnumerable<Product> GetProductsByQuantity(int quantity)
        {
            return DbSet.Where(product => product.Quantity == quantity);
        }
    }
}
