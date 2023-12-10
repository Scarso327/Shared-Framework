namespace Scarso.Framework.Domain.Entities.Auditing.Interfaces;

public interface ICreatedAt
{
    public Guid CreatedByUserId { get; set; }

    public DateTime CreatedAt { get; set; }
}
