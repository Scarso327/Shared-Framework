using Scarso.Framework.Domain.Entities.Interfaces;
using Scarso.Framework.Domain.Events.Interfaces;

namespace Scarso.Framework.Domain.Entities;

public abstract class Entity : IEntity, IHasDomainEvents
{
    protected Entity() { }

    public Guid Id { get; set; }

    #region Domain Events
    private readonly List<IDomainEvent> _domainEvents = [];

    public void AddDomainEvent(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);

    public void ClearDomainEvents() => _domainEvents.Clear();

    public IDomainEvent[] GetDomainEvents() => _domainEvents.ToArray();

    public bool HasDomainEvents() => _domainEvents.Count != 0;

    public void RemoveDomainEvent(IDomainEvent domainEvent) => _domainEvents.Remove(domainEvent);
    #endregion
}
