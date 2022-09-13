using RestaurantControl.Models.Restaurant;

namespace RestaurantControl.Core.Services.OrderItems;

public interface IOrderItemService
{
    public Task<OrderItemDto> GetOrderItemById(int id);

    public Task<OrderItemDto> AddOrderItemAsync(OrderItemDto dto);

    public Task<OrderItemDto> DeleteOrderItemAsync(int id);
}
