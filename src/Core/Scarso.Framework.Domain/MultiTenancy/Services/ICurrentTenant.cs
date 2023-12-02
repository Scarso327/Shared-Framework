using Scarso.Framework.Domain.MultiTenancy.Interfaces;

namespace Scarso.Framework.Domain.MultiTenancy.Services;

public interface ICurrentTenant
{
    public ITenant? Tenant { get; }

    public void SetTenantById(Guid? tenant);
}