using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Scarso.Framework.Domain.Common.Exceptions;
using Scarso.Framework.Domain.MultiTenancy.Configuration;
using Scarso.Framework.Domain.MultiTenancy.Exceptions;
using Scarso.Framework.Domain.MultiTenancy.Services;

namespace Scarso.Framework.AspNetCore.MultiTenancy;

internal class MultiTenancyMiddleware(RequestDelegate _next)
{
    public Task Invoke(HttpContext httpContext, ITenantResolver tenantResolver, ICurrentTenant currentTenant, IOptions<MultiTenancyConfig> options)
    {
        var tenantId = tenantResolver.ResolveTenantId();

        if (tenantId is not null)
            currentTenant.SetTenantById(tenantId);

        if (options.Value is null)
            throw new MissingConfigException(typeof(MultiTenancyConfig));

        if (options.Value.IsRequired && currentTenant.Tenant is null)
            throw new FailedToResolveTenantException();

        return _next(httpContext);
    }
}
