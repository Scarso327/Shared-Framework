using Microsoft.EntityFrameworkCore;
using Scarso.Framework.Domain.MultiTenancy.Services;
using Scarso.Framework.Infrastructure.EntityFramework.Persistence;
using Scarso.Framework.Infrastructure.EntityFramework.Persistence.Extensions;
using Scarso.Framework.Samples.APITenantResolution.Domain.MultiTenancy.Entities;
using System.Reflection;

namespace Scarso.Framework.Samples.APITenantResolution.Infrastructure.Persistence;

public class WeatherDbContext(DbContextOptions options, ICurrentTenant currentTenant) : BaseDbContext(options, currentTenant)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        modelBuilder.ApplyAutoSeeding(Assembly.GetAssembly(typeof(Tenant))!);

        base.OnModelCreating(modelBuilder);
    }
}
