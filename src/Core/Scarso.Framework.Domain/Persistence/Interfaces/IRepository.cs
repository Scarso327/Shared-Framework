using Scarso.Framework.Domain.Entities.Interfaces;
using System.Linq.Expressions;

namespace Scarso.Framework.Domain.Persistence.Interfaces;

public interface IRepository<T> where T : class, IEntity
{
    public IUnitOfWork UnitOfWork { get; }

    public void Add(T entity);

    public void AddRange(IEnumerable<T> entities);

    public Task AddAsync(T entity, CancellationToken cancellationToken = default);

    public Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);

    public Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    public T? SingleOrDefault(Expression<Func<T, bool>> expression);

    public Task<T?> SingleOrDefaultAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);

    public void Update(T entity);

    public void UpdateRange(IEnumerable<T> entities);

    public void Delete(T entity);

    public void DeleteRange(IEnumerable<T> entities);
}
