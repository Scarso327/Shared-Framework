using Microsoft.AspNetCore.Http;
using Scarso.Framework.Domain.Common.Extensions;
using Scarso.Framework.Domain.MultiTenancy.Services;

namespace Scarso.Framework.AspNetCore.MultiTenancy.Resolvers;

public class ResolveTenantIdFromSubDomain(IHttpContextAccessor _httpContextAccessor, ITenantStore _tenantStore) : ITenantResolverMethod
{
    public const string TenantHttpHeaderKey = "x-tenantid";

    public Guid? ResolveTenantId()
    {
        var httpContext = _httpContextAccessor.HttpContext;

        if (httpContext is null)
            return null;

        var subDomain = httpContext.Request.Host.Host.Split(".").FirstOrDefault();

        if (subDomain.IsNullOrWhiteSpace()) return null;

#pragma warning disable CS8604 // Possible null reference argument.
        var tenant = _tenantStore.Get(subDomain);
#pragma warning restore CS8604 // Possible null reference argument.

        return tenant?.Id;
    }
}
