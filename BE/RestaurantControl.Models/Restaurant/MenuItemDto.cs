namespace RestaurantControl.Models.Restaurant;

public class MenuItemDto
{
    public int Id { get; set; }

    public int? MenuCategoryId { get; set; }

    public string Name { get; set; }

    public string PhotoUrl { get; set; }

    public double Price { get; set; }
}
