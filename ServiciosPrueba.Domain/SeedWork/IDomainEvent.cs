using System;
using MediatR;

namespace ServicioPrueba.Domain.SeedWork
{
    public interface IDomainEvent : INotification
    {
        DateTime OccurredOn { get; }
    }
}