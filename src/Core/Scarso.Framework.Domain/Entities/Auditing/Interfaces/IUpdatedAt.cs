namespace Scarso.Framework.Domain.Entities.Auditing.Interfaces;

public interface IUpdatedAt
{
    public DateTime? LastUpdated { get; set; }
}
