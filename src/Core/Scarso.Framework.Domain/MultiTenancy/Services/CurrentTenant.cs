using Scarso.Framework.Domain.MultiTenancy.Interfaces;

namespace Scarso.Framework.Domain.MultiTenancy.Services;

public class CurrentTenant : ICurrentTenant
{
    private static readonly AsyncLocal<CurrentTenantHolder> _holder = new();

    public ITenant? Value
    {
        get => _holder.Value?.Tenant;
        set
        {
            var holder = _holder.Value;

            if (holder is not null)
                holder.Tenant = null;

            if (value is not null)
                _holder.Value = new CurrentTenantHolder()
                {
                    Tenant = value
                };
        }
    }

    public class CurrentTenantHolder
    {
        public ITenant? Tenant { get; set; }
    }
}