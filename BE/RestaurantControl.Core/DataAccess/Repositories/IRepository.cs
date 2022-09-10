using System.Linq.Expressions;

namespace RestaurantControl.Core.DataAccess.Repositories;

public interface IRepository
{
}

public interface IRepository<TEntity> : IRepository
    where TEntity : class
{
    IQueryable<TEntity> Get();

    Task<bool> AnyAsync(CancellationToken cancellationToken = default);

    Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);

    TEntity Find(params object[] id);

    Task<TEntity> FindAsync(CancellationToken cancellationToken, params object[] id);

    TEntity Create(TEntity entity);

    Task CreateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken);

    Task<TEntity> UpdateAsync(TEntity entityToUpdate, Guid id, CancellationToken cancellationToken);

    Task<TEntity> DeleteAsync(CancellationToken cancellationToken, params object[] id);

    void Delete(TEntity entity);

    void DeleteRange(IEnumerable<TEntity> entities);
}
