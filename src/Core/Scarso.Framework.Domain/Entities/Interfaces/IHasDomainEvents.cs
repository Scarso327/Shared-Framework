using Scarso.Framework.Domain.Events.Interfaces;

namespace Scarso.Framework.Domain.Entities.Interfaces;

public interface IHasDomainEvents
{
    public void AddDomainEvent(IDomainEvent domainEvent);

    public IDomainEvent[] GetDomainEvents();

    public bool HasDomainEvents();

    public void RemoveDomainEvent(IDomainEvent domainEvent);

    public void ClearDomainEvents();
}
