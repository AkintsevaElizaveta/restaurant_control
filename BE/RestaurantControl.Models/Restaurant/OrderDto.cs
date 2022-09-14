namespace RestaurantControl.Models.Restaurant;

public class OrderDto
{
    public int Id { get; set; }

    public int? TableId { get; set; }

    public int? WaiterId { get; set; }

    public List<OrderItemDto> OrderItems { get; set; }

    public bool IsClosed { get; set; }
}
