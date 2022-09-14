namespace RestaurantControl.Core.DataAccess.Manager;

public interface IManager
{
    int Save();

    void BeginTransaction();

    Task BeginTransactionAsync();

    Task CommitTransactionAsync();

    Task RollbackTransactionAsync();

    void CommitTransaction();

    void RollbackTransaction();

    Task<int> SaveAsync();

    Task<int> SaveAsync(CancellationToken cancellationToken);
}
