namespace RestaurantControl.Models.Restaurant;

public class MenuCategoryDto
{
    public int Id { get; set; }

    public string Name { get; set; }

    public List<MenuItemDto> MenuItems { get; set; }
}
