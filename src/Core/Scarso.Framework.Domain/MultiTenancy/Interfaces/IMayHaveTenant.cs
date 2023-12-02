﻿using Scarso.Framework.Domain.Entities.Interfaces;

namespace Scarso.Framework.Domain.MultiTenancy.Interfaces;

public interface IMayHaveTenant : IEntity
{
    public Guid? TenantId { get; set; }
}
