using RestaurantControl.Core.DataAccess.Context;
using RestaurantControl.Core.DataAccess.DbModels;
using RestaurantControl.Core.DataAccess.Repositories;

namespace RestaurantControl.Core.DataAccess.Manager;

public class RestaurantManager : Manager<RestaurantDbContext>, IRestaurantManager
{
    private IRepository<User> _userRepository;
    private IRepository<Table> _tablesRepository;
    private IRepository<Waiter> _waitersRepository;
    private IRepository<MenuCategory> _categoriesRepository;
    private IRepository<MenuItem> _menuItemsRepository;
    private IRepository<Order> _ordersRepository;
    private IRepository<OrderItem> _orderItemsRepository;

    public RestaurantManager(RestaurantDbContext context)
        : base(context)
    {
        if (context == null)
        {
            throw new InvalidOperationException("Entity.DbContext instance is expected as a dbContext parameter.");
        }
    }

    public IRepository<User> UserRepository => _userRepository ??= new Repository<User>(Context, Context.Users);

    public IRepository<Table> TablesRepository => _tablesRepository ??= new Repository<Table>(Context, Context.Tables);

    public IRepository<Waiter> WaitersRepository => _waitersRepository ??= new Repository<Waiter>(Context, Context.Waiters);

    public IRepository<MenuCategory> CategoriesRepository => _categoriesRepository ??= new Repository<MenuCategory>(Context, Context.MenuCategories);

    public IRepository<MenuItem> MenuItemsRepository => _menuItemsRepository ??= new Repository<MenuItem>(Context, Context.MenuItems);

    public IRepository<Order> OrdersRepository => _ordersRepository ??= new Repository<Order>(Context, Context.Orders);

    public IRepository<OrderItem> OrderItemsRepository => _orderItemsRepository ??= new Repository<OrderItem>(Context, Context.OrderItems);
}
