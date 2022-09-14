using Microsoft.EntityFrameworkCore;
using RestaurantControl.Core.DataAccess.Context;
using RestaurantControl.Core.DataAccess.Manager;
using RestaurantControl.Core.Services.MenuCategories;
using RestaurantControl.Core.Services.MenuItems;
using RestaurantControl.Core.Services.OrderItems;
using RestaurantControl.Core.Services.Orders;
using RestaurantControl.Core.Services.Tables;
using RestaurantControl.Core.Services.Waiters;

namespace RestaurantControl.Api.Extensions;

public static class ApiConfigExtensions
{
    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddDbContext<RestaurantDbContext>();
        AddManagers(services);
        AddServices(services);
    }

    public static void UpdateDatabase(this IServiceProvider serviceProvider)
    {
        using var serviceScope = serviceProvider.CreateScope();
        var dbContext = serviceScope.ServiceProvider.GetRequiredService<RestaurantDbContext>();

        dbContext.Database.GenerateCreateScript();
        dbContext.Database.EnsureCreated();
        dbContext.Database.Migrate();
    }

    private static void AddServices(IServiceCollection services)
    {
        services.AddScoped<ITableService, TableService>();
        services.AddScoped<IWaiterService, WaiterService>();
        services.AddScoped<IMenuCategoryService, MenuCategoryService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IOrderItemService, OrderItemService>();
        services.AddScoped<IMenuItemService, MenuItemService>();
    }

    private static void AddManagers(IServiceCollection services)
    {
        services.AddScoped<IRestaurantManager, RestaurantManager>();
    }
}
