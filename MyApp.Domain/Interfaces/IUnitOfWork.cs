using MyApp.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        CommandResponse Commit();
    }
}
