using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace RestaurantControl.Core.DataAccess.Manager;

public abstract class Manager<TContext> : IManager
    where TContext : DbContext
{
    private IDbContextTransaction _transaction;

    protected Manager(TContext context)
    {
        Context = context;
    }

    protected TContext Context { get; }

    public void BeginTransaction()
    {
        _transaction = Context.Database.BeginTransaction();
    }

    public async Task BeginTransactionAsync()
    {
        _transaction = await Context.Database.BeginTransactionAsync();
    }

    public void CommitTransaction()
    {
        if (_transaction != null)
        {
            _transaction.Commit();
            _transaction = null;
        }
    }

    public async Task CommitTransactionAsync()
    {
        if (_transaction != null)
        {
            await _transaction.CommitAsync();
            _transaction = null;
        }
    }

    public void RollbackTransaction()
    {
        if (_transaction != null)
        {
            _transaction.Rollback();
            _transaction = null;
        }
    }

    public async Task RollbackTransactionAsync()
    {
        if (_transaction != null)
        {
            await _transaction.RollbackAsync();
            _transaction = null;
        }
    }

    public int Save()
    {
        int result = 0;

        try
        {
            result = Context.SaveChanges();
        }
        catch (InvalidOperationException ex)
        {
            throw new InvalidOperationException(ex.Message, ex);
        }
        catch (Exception updateEx)
        {
            throw new InvalidOperationException("Updating database error.", updateEx);
        }

        return result;
    }

    public Task<int> SaveAsync()
    {
        return Context.SaveChangesAsync();
    }

    public Task<int> SaveAsync(CancellationToken cancellationToken)
    {
        return Context.SaveChangesAsync(cancellationToken);
    }
}
