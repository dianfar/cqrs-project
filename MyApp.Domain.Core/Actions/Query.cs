using MyApp.Domain.Core.Events;
using FluentValidation.Results;
using System;
using MediatR;

namespace MyApp.Domain.Core.Queries
{
    public abstract class Query<T> : Message, IRequest<T>
    {
        public abstract bool IsValid();
    }
}
