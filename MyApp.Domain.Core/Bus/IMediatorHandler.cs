using MyApp.Domain.Core.Commands;
using MyApp.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand(Command command);
        Task<T> GetResult<T>(Query<T> command);
        Task RaiseEvent(Event @event);
    }
}
