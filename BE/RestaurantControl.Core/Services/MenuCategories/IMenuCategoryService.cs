using RestaurantControl.Models.Restaurant;

namespace RestaurantControl.Core.Services.MenuCategories;

public interface IMenuCategoryService
{
    public Task<IEnumerable<MenuCategoryDto>> GetAllMenuCategoriesAsync();

    public Task<MenuCategoryDto> GetMenuCategoryById(int id);

    public Task<MenuCategoryDto> AddMenuCategoryAsync(MenuCategoryDto dto);

    public Task<MenuCategoryDto> DeleteMenuCategoryAsync(int id);
}
