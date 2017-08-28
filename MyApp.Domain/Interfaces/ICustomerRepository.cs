using MyApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer GetByEmail(string email);
    }
}
