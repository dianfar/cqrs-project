using MyApp.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Domain.Models
{
    public class Product : Entity
    {
        public Product(Guid id, string name, int quantity)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
        }

        protected Product() { }

        public string Name { get; private set; }

        public int Quantity { get; private set; }
    }
}
