using Scarso.Framework.Domain.MultiTenancy.Interfaces;

namespace Scarso.Framework.Domain.MultiTenancy.Services;

public interface ITenantStore
{
    public ITenant? Get(Guid id);

    public ITenant? Get(string subDomain);
}
