using RestaurantControl.Core.DataAccess.DbModels;
using RestaurantControl.Core.DataAccess.Repositories;

namespace RestaurantControl.Core.DataAccess.Manager;

public interface IRestaurantManager : IManager
{
    IRepository<User> UserRepository { get; }

    IRepository<Table> TablesRepository { get; }

    IRepository<Waiter> WaitersRepository { get; }

    IRepository<MenuCategory> CategoriesRepository { get; }

    IRepository<MenuItem> MenuItemsRepository { get; }

    IRepository<Order> OrdersRepository { get; }

    IRepository<OrderItem> OrderItemsRepository { get; }
}
