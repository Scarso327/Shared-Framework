namespace Scarso.Framework.Domain.Events.Interfaces;

public interface IEvent
{
    public Guid Id { get; }

    public DateTime When { get; }
}
