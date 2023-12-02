using Scarso.Framework.Domain.Events.Interfaces;

namespace Scarso.Framework.Domain.Events;

public abstract record DomainEvent : IDomainEvent
{
    public DomainEvent()
    {
        Id = Guid.NewGuid();
        When = DateTime.UtcNow;
    }

    public Guid Id { get; protected set; }

    public DateTime When { get; protected set; }
}