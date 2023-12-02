
using Scarso.Framework.Domain.MultiTenancy.Configuration;

namespace Scarso.Framework.Domain.MultiTenancy.Services;

public class TenantResolver(MultiTenancyConfig config, IServiceProvider serviceProvider) : ITenantResolver
{
    public Guid? ResolveTenantId()
    {
        if (config.ResolverTypes.Count == 0)
            return null;

        foreach (var resolverType in config.ResolverTypes)
        {
            if (serviceProvider.GetService(resolverType) is not ITenantResolverMethod resolver) continue;

            var tenantId = resolver.ResolveTenantId();

            if (tenantId is null || tenantId == default(Guid)) continue;

            return tenantId;
        }

        return null;
    }
}
