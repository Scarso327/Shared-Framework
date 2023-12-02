namespace Scarso.Framework.Domain.Persistence.Interfaces;

public interface IUnitOfWork : IDisposable, IAsyncDisposable
{
    public Task SaveChangesAsync(CancellationToken cancellationToken = default);
}
