using MyApp.Domain.Core.Bus;
using MyApp.Domain.Core.Commands;
using MyApp.Domain.Core.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Core.Bus
{
    public sealed class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator mediator;

        public MediatorHandler(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public Task SendCommand<T>(T command) where T : Command
        {
            return mediator.Send(command);
        }

        public Task RaiseEvent<T>(T @event) where T : Event
        {
            return mediator.Publish(@event);
        }
    }
}
