using Scarso.Framework.Domain.Entities.Interfaces;
using Scarso.Framework.Domain.Persistence.Interfaces;

namespace Scarso.Framework.Infrastructure.EntityFramework.Persistence;

public abstract class BaseRepository<T> : IRepository<T> where T : class, IEntity
{
    private readonly BaseDbContext _context;
    public IUnitOfWork UnitOfWork => _context;

    protected BaseRepository(BaseDbContext context) => _context = context;

    public void Add(T entity) => _context.Set<T>().Add(entity);

    public void AddRange(IEnumerable<T> entities) => _context.Set<T>().AddRange(entities);

    public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
        => await _context.Set<T>().AddAsync(entity, cancellationToken);

    public async Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        => await _context.Set<T>().AddRangeAsync(entities, cancellationToken);

    public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        => await _context.Set<T>().FindAsync(new object[] { id }, cancellationToken);

    public void Update(T entity) => _context.Set<T>().Update(entity);

    public void UpdateRange(IEnumerable<T> entities) => _context.Set<T>().UpdateRange(entities);

    public void Delete(T entity) => _context.Set<T>().Remove(entity);

    public void DeleteRange(IEnumerable<T> entities) => _context.Set<T>().RemoveRange(entities);
}
