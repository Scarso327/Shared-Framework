using Microsoft.AspNetCore.Http;
using Scarso.Framework.Domain.MultiTenancy.Services;

namespace Scarso.Framework.AspNetCore.MultiTenancy.Resolvers;

public class ResolveTenantIdFromHeader(IHttpContextAccessor _httpContextAccessor) : ITenantResolverMethod
{
    public const string TenantHttpHeaderKey = "x-tenantid";

    public Guid? ResolveTenantId()
    {
        var httpContext = _httpContextAccessor.HttpContext;

        if (httpContext is null)
            return null;

        if (httpContext.Request.Headers.TryGetValue(TenantHttpHeaderKey, out var headerValueTenantId) 
            && Guid.TryParse(headerValueTenantId, out Guid tenantId))
            return tenantId;

        return null;
    }
}
