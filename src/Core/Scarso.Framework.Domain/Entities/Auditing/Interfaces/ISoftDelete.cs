using Scarso.Framework.Domain.Entities.Interfaces;

namespace Scarso.Framework.Domain.Entities.Auditing.Interfaces;

public interface ISoftDelete : IEntity
{
    public Guid? DeletedByUserId { get; set; }

    public bool IsDeleted { get; set; }

    public void Delete(Guid? deletedByUserId = null)
    {
        // TODO - ICurrentUser to populate with Repo Methods
        // We currently don't pass in the user id and instead projects using this intercept saves and force set the property
        // The implementation in the BaseRepository class could maybe access ICurrentUser and do this, just have to consider
        // circular dependency for certain approachs as ICurrentUser implementations use repositories in some older instances
        DeletedByUserId = deletedByUserId;
        IsDeleted = true;
    }
}
