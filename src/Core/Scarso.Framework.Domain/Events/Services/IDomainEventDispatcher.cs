using Scarso.Framework.Domain.Entities.Interfaces;

namespace Scarso.Framework.Domain.Events.Services;

public interface IDomainEventDispatcher
{
    Task DispatchAsync(IEnumerable<IHasDomainEvents > entitiesWithDomainEvents, CancellationToken cancellationToken = default);
}
