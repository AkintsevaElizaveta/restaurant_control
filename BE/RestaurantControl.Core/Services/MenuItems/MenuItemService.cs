using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestaurantControl.Core.DataAccess.DbModels;
using RestaurantControl.Core.DataAccess.Manager;
using RestaurantControl.Models.Restaurant;

namespace RestaurantControl.Core.Services.MenuItems;

public class MenuItemService : IMenuItemService
{
    private readonly IRestaurantManager _manager;
    private readonly IMapper _mapper;

    public MenuItemService(
        IRestaurantManager manager,
        IMapper mapper)
    {
        _manager = manager;
        _mapper = mapper;
    }

    public async Task<MenuItemDto> GetMenuItemById(int id)
    {
        var menuItem = await _manager.MenuItemsRepository.Get()
            .AsNoTracking()
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync();

        var menuItemDto = _mapper.Map<MenuItemDto>(menuItem);

        return menuItemDto;
    }

    public async Task<IEnumerable<MenuItemDto>> GetMenuItemsByCategoryId(int id)
    {
        var menuItems = await _manager.MenuItemsRepository.Get()
            .AsNoTracking()
            .Where(x => x.MenuCategoryId == id)
            .ToListAsync();

        var menuItemsDto = menuItems.Select(i => _mapper.Map<MenuItemDto>(i));

        return menuItemsDto;
    }

    public async Task<MenuItemDto> AddMenuItemAsync(MenuItemDto dto)
    {
        var model = _mapper.Map<MenuItem>(dto);

        var created = _manager.MenuItemsRepository.Create(model);
        await _manager.SaveAsync();

        var createdDto = _mapper.Map<MenuItemDto>(created);

        return createdDto;
    }

    public async Task<MenuItemDto> DeleteMenuItemAsync(int id)
    {
        var menuItem = await _manager.MenuItemsRepository.Get()
            .AsNoTracking()
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync();

        _manager.MenuItemsRepository.Delete(menuItem);
        await _manager.SaveAsync();

        var deletedDto = _mapper.Map<MenuItemDto>(menuItem);

        return deletedDto;
    }
}
