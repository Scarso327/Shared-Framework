using Microsoft.AspNetCore.Builder;

namespace Scarso.Framework.AspNetCore.MultiTenancy.Extensions;

public static class IApplicationBuilderExtensions
{
    public static IApplicationBuilder UseMultiTenancy(this IApplicationBuilder applicationBuilder)
        => applicationBuilder.UseMiddleware<MultiTenancyMiddleware>();
}
