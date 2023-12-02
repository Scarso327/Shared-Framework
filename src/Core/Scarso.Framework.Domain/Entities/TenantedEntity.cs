using Scarso.Framework.Domain.MultiTenancy.Interfaces;

namespace Scarso.Framework.Domain.Entities;

public abstract class TenantedEntity : Entity, IMustHaveTenant
{
    public Guid TenantId { get; set; }
}
