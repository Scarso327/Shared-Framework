using Scarso.Framework.Domain.MultiTenancy.Interfaces;
using Scarso.Framework.Domain.MultiTenancy.Services;
using Scarso.Framework.Domain.Persistence.Interfaces;

namespace Scarso.Framework.Infrastructure.EntityFramework.MultiTenancy.Services;

public class TenantStore<TTenant>(IRepository<TTenant> tenantRepository) : ITenantStore
    where TTenant : class, ITenant
{
    private readonly IRepository<TTenant> _tenantRepository = tenantRepository;

    // TODO: Add some sort of cache at this point?

    public ITenant? Get(Guid id) => _tenantRepository.SingleOrDefault(e => e.Id == id);

    public ITenant? Get(string subDomain) => _tenantRepository.SingleOrDefault(e => e.SubDomain == subDomain);
}
