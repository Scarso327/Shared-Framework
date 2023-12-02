using Castle.DynamicProxy;
using Scarso.Framework.Domain.Entities.Interfaces;

namespace Scarso.Framework.Infrastructure.EntityFramework.Persistence.Extensions;

public static class IEntityExtensions
{
    /// <summary>
    /// Allows us to get the POCO entity type even if EF has wrapped us with a proxy
    /// </summary>
    public static Type GetEntityType(this IEntity entity) => (entity is IProxyTargetAccessor proxy) ? proxy.GetType().BaseType! : entity.GetType();
}
