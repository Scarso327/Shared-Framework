using Scarso.Framework.Domain.MultiTenancy.Interfaces;

namespace Scarso.Framework.Domain.MultiTenancy.Services;

public interface ICurrentTenant
{
    public ITenant? Value { get; set; }

    public bool HasValue => Value is not null;
}