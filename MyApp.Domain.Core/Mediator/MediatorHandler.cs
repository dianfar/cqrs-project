using MyApp.Domain.Core.Bus;
using MyApp.Domain.Core.Commands;
using MyApp.Domain.Core.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MyApp.Domain.Core.Queries;

namespace MyApp.Domain.Core.Bus
{
    public sealed class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator mediator;

        public MediatorHandler(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public Task SendCommand(Command command)
        {
            return mediator.Send(command);
        }

        public Task RaiseEvent(Event @event)
        {
            return mediator.Publish(@event);
        }

        public Task<T> GetResult<T>(Query<T> query)
        {
            return mediator.Send<T>(query);
        }
    }
}
