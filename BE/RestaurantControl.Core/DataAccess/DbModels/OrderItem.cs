namespace RestaurantControl.Core.DataAccess.DbModels;

public class OrderItem : EntityInfo
{
    public int? OrderId { get; set; }

    public int? MenuItemId { get; set; }

    // public MenuItem MenuItem { get; set; }
}
