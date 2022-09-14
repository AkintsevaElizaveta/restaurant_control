using RestaurantControl.Models.Restaurant;

namespace RestaurantControl.Core.Services.MenuItems;

public interface IMenuItemService
{
    public Task<MenuItemDto> GetMenuItemById(int id);

    public Task<IEnumerable<MenuItemDto>> GetMenuItemsByCategoryId(int id);

    public Task<MenuItemDto> AddMenuItemAsync(MenuItemDto dto);

    public Task<MenuItemDto> DeleteMenuItemAsync(int id);
}
