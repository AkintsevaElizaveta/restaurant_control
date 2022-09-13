using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestaurantControl.Core.DataAccess.DbModels;
using RestaurantControl.Core.DataAccess.Manager;
using RestaurantControl.Models.Restaurant;

namespace RestaurantControl.Core.Services.OrderItems;

public class OrderItemService : IOrderItemService
{
    private readonly IRestaurantManager _manager;
    private readonly IMapper _mapper;

    public OrderItemService(
        IRestaurantManager manager,
        IMapper mapper)
    {
        _manager = manager;
        _mapper = mapper;
    }

    public async Task<OrderItemDto> GetOrderItemById(int id)
    {
        var orderItem = await _manager.OrderItemsRepository.Get()
            .AsNoTracking()
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync();

        var orderItemDto = _mapper.Map<OrderItemDto>(orderItem);

        return orderItemDto;
    }

    public async Task<OrderItemDto> AddOrderItemAsync(OrderItemDto dto)
    {
        var model = _mapper.Map<OrderItem>(dto);

        var created = _manager.OrderItemsRepository.Create(model);
        await _manager.SaveAsync();

        var createdDto = _mapper.Map<OrderItemDto>(created);

        return createdDto;
    }

    public async Task<OrderItemDto> DeleteOrderItemAsync(int id)
    {
        var orderItem = await _manager.OrderItemsRepository.Get()
            .AsNoTracking()
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync();

        _manager.OrderItemsRepository.Delete(orderItem);
        await _manager.SaveAsync();

        var deletedDto = _mapper.Map<OrderItemDto>(orderItem);

        return deletedDto;
    }
}
