using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestaurantControl.Core.DataAccess.DbModels;
using RestaurantControl.Core.DataAccess.Manager;
using RestaurantControl.Models.Restaurant;

namespace RestaurantControl.Core.Services.MenuCategories;

public class MenuCategoryService : IMenuCategoryService
{
    private readonly IRestaurantManager _manager;
    private readonly IMapper _mapper;

    public MenuCategoryService(
        IRestaurantManager manager,
        IMapper mapper)
    {
        _manager = manager;
        _mapper = mapper;
    }

    public async Task<IEnumerable<MenuCategoryDto>> GetAllMenuCategoriesAsync()
    {
        var categoriesModels = await _manager.CategoriesRepository.Get()
            .AsNoTracking()

            .ToListAsync();

        var categories = categoriesModels.Select(category => _mapper.Map<MenuCategoryDto>(category));

        foreach(var category in categoriesModels)
        {
            var menuItems = await _manager.MenuItemsRepository.Get()
                .AsNoTracking()
                .Where(x => x.MenuCategoryId == category.Id)
                .ToListAsync();

            category.MenuItems = new List<MenuItem>();
            category.MenuItems.AddRange(menuItems);
        }

        return categories;
    }

    public async Task<MenuCategoryDto> GetMenuCategoryById(int id)
    {
        var category = await _manager.CategoriesRepository.Get()
            .AsNoTracking()
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync();

        var categoryDto = _mapper.Map<MenuCategoryDto>(category);

        return categoryDto;
    }

    public async Task<MenuCategoryDto> AddMenuCategoryAsync(MenuCategoryDto dto)
    {
        var model = _mapper.Map<MenuCategory>(dto);

        var created = _manager.CategoriesRepository.Create(model);
        await _manager.SaveAsync();

        var createdDto = _mapper.Map<MenuCategoryDto>(created);

        return createdDto;
    }

    public async Task<MenuCategoryDto> DeleteMenuCategoryAsync(int id)
    {
        var category = await _manager.CategoriesRepository.Get()
            .AsNoTracking()
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync();

        _manager.CategoriesRepository.Delete(category);
        await _manager.SaveAsync();

        var deletedDto = _mapper.Map<MenuCategoryDto>(category);

        return deletedDto;
    }
}
