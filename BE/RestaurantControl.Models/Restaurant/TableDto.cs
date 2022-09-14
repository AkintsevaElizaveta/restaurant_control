namespace RestaurantControl.Models.Restaurant;

public class TableDto
{
    public int Id { get; set; }

    public int Number { get; set; }

    public int? WaiterId { get; set; }

    public int? OrderId { get; set; }

    public int PositionX { get; set; }

    public int PositionY { get; set; }
}
