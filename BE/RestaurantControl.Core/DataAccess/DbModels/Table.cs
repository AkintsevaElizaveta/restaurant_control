namespace RestaurantControl.Core.DataAccess.DbModels;

public class Table : EntityInfo
{
    public int Number { get; set; }

    public int? WaiterId { get; set; }

    // public Waiter Waiter { get; set; }
    public int? OrderId { get; set; }

    // public Order Order { get; set; }
    public int PositionX { get; set; }

    public int PositionY { get; set; }
}
