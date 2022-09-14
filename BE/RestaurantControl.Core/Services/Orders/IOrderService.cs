using RestaurantControl.Models.Restaurant;

namespace RestaurantControl.Core.Services.Orders;

public interface IOrderService
{
    public Task<IEnumerable<OrderDto>> GetAllOrdersAsync();

    public Task<OrderDto> GetOrderById(int id);

    public Task<OrderDto> AddOrderAsync(OrderDto dto);

    public Task<OrderDto> DeleteOrderAsync(int id);
}
