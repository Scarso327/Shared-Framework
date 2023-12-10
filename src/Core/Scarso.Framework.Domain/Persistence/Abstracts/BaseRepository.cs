using Scarso.Framework.Domain.Common.Extensions;
using Scarso.Framework.Domain.Entities.Auditing.Interfaces;
using Scarso.Framework.Domain.Entities.Interfaces;
using Scarso.Framework.Domain.Persistence.Interfaces;
using System.Linq.Expressions;

namespace Scarso.Framework.Domain.Persistence.Abstracts;

public abstract class BaseRepository<T> : IRepository<T> where T : class, IEntity
{
	public IUnitOfWork UnitOfWork { get; private set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
	public BaseRepository() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

	protected BaseRepository(IUnitOfWork unitOfWork) => UnitOfWork = unitOfWork;

	public abstract void Add(T entity);

	public abstract Task AddAsync(T entity, CancellationToken cancellationToken = default);

	public abstract void AddRange(IEnumerable<T> entities);

	public abstract Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);

	protected abstract void PreformDelete(T entity);

	public virtual void Delete(T entity)
	{
		if (typeof(T).HasInterface<ISoftDelete>())
		{
			((ISoftDelete)entity).Delete(); // Comment in method about user id parameter

			Update(entity);
			return;
		}

		PreformDelete(entity);
	}

	protected abstract void PreformDeleteRange(IEnumerable<T> entities);

	public virtual void DeleteRange(IEnumerable<T> entities)
	{
		if (typeof(T).HasInterface<ISoftDelete>())
		{
			foreach (var entity in entities.Cast<ISoftDelete>())
				entity.Delete(); // Comment in method about user id parameter

			UpdateRange(entities);
			return;
		}

		PreformDeleteRange(entities);
	}

	public abstract Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

	public abstract T? SingleOrDefault(Expression<Func<T, bool>> expression);

	public abstract Task<T?> SingleOrDefaultAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);

	public abstract void Update(T entity);

	public abstract void UpdateRange(IEnumerable<T> entities);
}
