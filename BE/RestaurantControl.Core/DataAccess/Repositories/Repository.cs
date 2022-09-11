using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace RestaurantControl.Core.DataAccess.Repositories;

public class Repository<TEntity> : IRepository<TEntity>
    where TEntity : class
{
    private readonly DbContext _context;
    private readonly DbSet<TEntity> _dbSet;

    public Repository(DbContext context, DbSet<TEntity> dbSet)
    {
        _context = context;
        _dbSet = dbSet;
    }

    public IQueryable<TEntity> Get()
    {
        return _dbSet;
    }

    public async Task<bool> AnyAsync(CancellationToken cancellationToken = default)
    {
        return await _dbSet.AnyAsync(cancellationToken);
    }

    public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
    {
        return await _dbSet.AnyAsync(predicate, cancellationToken);
    }

    public TEntity Find(params object[] id)
    {
        return _dbSet.Find(id);
    }

    public async Task<TEntity> FindAsync(CancellationToken cancellationToken, params object[] id)
    {
        return await _dbSet.FindAsync(id, cancellationToken);
    }

    public TEntity Create(TEntity entity)
    {
        var result = _dbSet.Add(entity);
        return result.Entity;
    }

    public Task CreateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken)
    {
        return _dbSet.AddRangeAsync(entities, cancellationToken);
    }

    public async Task<TEntity> UpdateAsync(TEntity entity, Guid id, CancellationToken cancellationToken)
    {
        var entityToUpdate = await FindAsync(cancellationToken, id);

        if (entityToUpdate == null)
        {
            throw new KeyNotFoundException($"There are no records with id: {id}");
        }

        _context.Entry(entityToUpdate).CurrentValues.SetValues(entity);

        return entityToUpdate;
    }

    public async Task<TEntity> DeleteAsync(CancellationToken cancellationToken, params object[] id)
    {
        var entityToDelete = await FindAsync(cancellationToken, id);

        if (entityToDelete != null)
        {
            Delete(entityToDelete);
        }

        return entityToDelete;
    }

    public void Delete(TEntity entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        if (_context.Entry(entity).State == EntityState.Detached)
        {
            _dbSet.Attach(entity);
        }

        _dbSet.Remove(entity);
    }

    public void DeleteRange(IEnumerable<TEntity> entities)
    {
        foreach (var entity in entities)
        {
            Delete(entity);
        }
    }
}
