namespace Scarso.Framework.Domain.MultiTenancy.Services;

public interface ITenantResolver
{
    public Guid? ResolveTenantId();
}
