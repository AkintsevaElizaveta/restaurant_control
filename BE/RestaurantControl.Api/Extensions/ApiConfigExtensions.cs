using Microsoft.EntityFrameworkCore;
using RestaurantControl.Core.DataAccess.Context;
using RestaurantControl.Core.DataAccess.Manager;
using RestaurantControl.Core.Services.Tables;

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
    }

    private static void AddManagers(IServiceCollection services)
    {
        services.AddScoped<IRestaurantManager, RestaurantManager>();
    }
}
