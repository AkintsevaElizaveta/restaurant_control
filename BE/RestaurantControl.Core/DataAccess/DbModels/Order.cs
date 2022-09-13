namespace RestaurantControl.Core.DataAccess.DbModels;

public class Order : EntityInfo
{
    public int? TableId { get; set; }

    public int? WaiterId { get; set; }

    // public Waiter Waiter { get; set; }
    public List<OrderItem> OrderItems { get; set; }

    public bool IsClosed { get; set; }
}
