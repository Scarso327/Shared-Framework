using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Scarso.Framework.Domain.Entities.Auditing.Interfaces;
using Scarso.Framework.Domain.Entities.Interfaces;
using Scarso.Framework.Domain.Events.Services;
using Scarso.Framework.Domain.MultiTenancy.Interfaces;
using Scarso.Framework.Domain.MultiTenancy.Services;
using Scarso.Framework.Domain.Persistence.Interfaces;
using Scarso.Framework.Infrastructure.EntityFramework.Persistence.Extensions;

namespace Scarso.Framework.Infrastructure.EntityFramework.Persistence;

public abstract class BaseDbContext : DbContext, IUnitOfWork
{
    private readonly ICurrentTenant _currentTenant;
    private readonly IDomainEventDispatcher? _domainEventDispatcher;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    protected BaseDbContext() : base() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    protected BaseDbContext(DbContextOptions options, ICurrentTenant currentTenant) : base(options)
        => _currentTenant = currentTenant;

    protected BaseDbContext(DbContextOptions options, ICurrentTenant currentTenant, IDomainEventDispatcher domainEventDispatcher)
        : this(options, currentTenant)
        => _domainEventDispatcher = domainEventDispatcher;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyGlobalFilters<IMustHaveTenant>(e => e.TenantId == _currentTenant.Value!.Id);
        modelBuilder.ApplyGlobalFilters<IMayHaveTenant>(e => !e.TenantId.HasValue || (_currentTenant.Value != null && e.TenantId == _currentTenant.Value.Id));
		modelBuilder.ApplyGlobalFilters<ISoftDelete>(e => !e.IsDeleted);
	}

    public new async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entitiesWithDomainEvents = ChangeTracker.Entries<IHasDomainEvents>()
            .Select(e => e.Entity)
            .Where(e => e.HasDomainEvents())
            .ToArray();

        _ = await base.SaveChangesAsync(cancellationToken);

        if (_domainEventDispatcher is not null)
            await _domainEventDispatcher.DispatchAsync(entitiesWithDomainEvents, cancellationToken);
    }
}
