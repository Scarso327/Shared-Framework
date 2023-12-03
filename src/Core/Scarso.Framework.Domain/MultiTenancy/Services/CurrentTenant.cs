using Scarso.Framework.Domain.MultiTenancy.Interfaces;

namespace Scarso.Framework.Domain.MultiTenancy.Services;

public class CurrentTenant : ICurrentTenant
{
    private ITenant? _tenant;
    public ITenant? Tenant => _tenant;

    public void SetTenant(ITenant? tenant) => _tenant = tenant;
}
