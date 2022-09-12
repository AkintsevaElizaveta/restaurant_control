using Microsoft.EntityFrameworkCore;
using RestaurantControl.Core.DataAccess.DbModels;
using RestaurantControl.Core.DataAccess.Extensions;

namespace RestaurantControl.Core.DataAccess.Context;

public class RestaurantDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public DbSet<Table> Tables { get; set; }

    public DbSet<Waiter> Waiters { get; set; }

    public DbSet<MenuCategory> MenuCategories { get; set; }

    public DbSet<MenuItem> MenuItems { get; set; }

    public DbSet<Order> Orders { get; set; }

    public DbSet<OrderItem> OrderItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // base.OnModelCreating(modelBuilder);
        modelBuilder.Ignore<EntityInfo>();

        modelBuilder.Entity<User>(x =>
        {
            x.Property(i => i.Login).HasMaxLength(255);
            x.Property(i => i.Password).HasMaxLength(255);

            x.ApplyBaseModelConfiguration();
        });

        modelBuilder.Entity<Table>(x =>
        {
            x.HasIndex(i => i.WaiterId).IsUnique(false);
            x.HasIndex(i => i.OrderId).IsUnique(false);

            x.ApplyBaseModelConfiguration();
        });

        modelBuilder.Entity<Waiter>(x =>
        {
            x.Property(i => i.Name).HasMaxLength(255);

            x.ApplyBaseModelConfiguration();
        });

        modelBuilder.Entity<MenuCategory>(x =>
        {
            x.Property(i => i.Name).HasMaxLength(255);

            x.HasMany(i => i.MenuItems).WithOne();

            x.ApplyBaseModelConfiguration();
        });

        modelBuilder.Entity<MenuItem>(x =>
        {
            x.Property(i => i.Name).HasMaxLength(255);
            x.Property(i => i.PhotoUrl).HasMaxLength(255);

            x.HasIndex(i => i.MenuCategoryId).IsUnique(false);

            x.ApplyBaseModelConfiguration();
        });

        modelBuilder.Entity<Order>(x =>
        {
            x.HasIndex(i => i.TableId).IsUnique(false);
            x.HasIndex(i => i.WaiterId).IsUnique(false);

            x.HasMany(i => i.OrderItems).WithOne();

            x.ApplyBaseModelConfiguration();
        });

        modelBuilder.Entity<OrderItem>(x =>
        {
            x.HasIndex(i => i.OrderId).IsUnique(false);
            x.HasIndex(i => i.MenuItemId).IsUnique(false);

            x.ApplyBaseModelConfiguration();
        });
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=tcp:restaurantcontroller20220910.database.windows.net,1433;Initial Catalog=Restaurant;Persist Security Info=False;User ID=restaurant_admin_2022;Password=46564923-a228-4bbc-992b-13d121a799ab;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
    }
}
