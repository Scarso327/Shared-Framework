namespace Scarso.Framework.Domain.MultiTenancy.Services;

public interface ITenantResolverMethod
{
    public Guid? ResolveTenantId();
}
