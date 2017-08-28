using MyApp.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Domain.Commands
{
    public abstract class ProductCommand : Command
    {
        public Guid Id { get; protected set; }

        public string Name { get; protected set; }

        public int Quantity { get; protected set; }
    }
}
