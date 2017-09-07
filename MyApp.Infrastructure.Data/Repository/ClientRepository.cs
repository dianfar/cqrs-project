using MyApp.Domain.Interfaces;
using MyApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using MyApp.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyApp.Infrastructure.Data.Repository
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        public ClientRepository(MyAppContext context)
            : base(context)
        {
        }
    }
}
