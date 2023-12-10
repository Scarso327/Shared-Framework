using Microsoft.EntityFrameworkCore;
using Scarso.Framework.Domain.Entities.Interfaces;
using Scarso.Framework.Domain.Persistence.Abstracts;
using System.Linq.Expressions;

namespace Scarso.Framework.Infrastructure.EntityFramework.Persistence;

public class Repository<T>(BaseDbContext context) : BaseRepository<T>(context) where T : class, IEntity
{
    private readonly BaseDbContext _context = context;

    public override void Add(T entity) => _context.Set<T>().Add(entity);

    public override void AddRange(IEnumerable<T> entities) => _context.Set<T>().AddRange(entities);

    public override async Task AddAsync(T entity, CancellationToken cancellationToken = default)
        => await _context.Set<T>().AddAsync(entity, cancellationToken);

    public override async Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        => await _context.Set<T>().AddRangeAsync(entities, cancellationToken);

    public override async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        => await _context.Set<T>().FindAsync(new object[] { id }, cancellationToken);

    public override T? SingleOrDefault(Expression<Func<T, bool>> expression)
        => _context.Set<T>().SingleOrDefault(expression);

    public override Task<T?> SingleOrDefaultAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
        => _context.Set<T>().SingleOrDefaultAsync(expression, cancellationToken: cancellationToken);

    public override void Update(T entity) => _context.Set<T>().Update(entity);

    public override void UpdateRange(IEnumerable<T> entities) => _context.Set<T>().UpdateRange(entities);

    protected override void PreformDelete(T entity) => _context.Set<T>().Remove(entity);

	protected override void PreformDeleteRange(IEnumerable<T> entities) => _context.Set<T>().RemoveRange(entities);
}
