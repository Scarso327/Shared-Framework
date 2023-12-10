using Scarso.Framework.Domain.Entities.Interfaces;

namespace Scarso.Framework.Domain.Entities.Auditing.Interfaces;

public interface IAudited : IEntity, ICreatedAt, IUpdatedAt
{

}
