using MyApp.Domain.Core.Events;
using FluentValidation.Results;
using System;
using MediatR;

namespace MyApp.Domain.Core.Commands
{
    public abstract class Command : Message, IRequest
    {
        public abstract bool IsValid();
    }
}
