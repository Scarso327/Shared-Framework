using Microsoft.Extensions.Options;
using Scarso.Framework.Domain.Common.Exceptions;
using Scarso.Framework.Domain.MultiTenancy.Configuration;

namespace Scarso.Framework.Domain.MultiTenancy.Services;

public class TenantResolver(IOptions<MultiTenancyConfig> config, IServiceProvider serviceProvider) : ITenantResolver
{
    private readonly IServiceProvider _serviceProvider = serviceProvider;
    private readonly MultiTenancyConfig _config = config.Value ?? throw new MissingConfigException(typeof(MultiTenancyConfig));

    public Guid? ResolveTenantId()
    {
        if (_config.ResolverTypes.Count == 0)
            return null;

        foreach (var resolverType in _config.ResolverTypes)
        {
            if (_serviceProvider.GetService(resolverType) is not ITenantResolverMethod resolver) continue;

            var tenantId = resolver.ResolveTenantId();

            if (tenantId is null || tenantId == default(Guid)) continue;

            return tenantId;
        }

        return null;
    }
}
