using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestaurantControl.Core.DataAccess.DbModels;
using RestaurantControl.Core.DataAccess.Manager;
using RestaurantControl.Models.Restaurant;

namespace RestaurantControl.Core.Services.Orders;

public class OrderService : IOrderService
{
    private readonly IRestaurantManager _manager;
    private readonly IMapper _mapper;

    public OrderService(
        IRestaurantManager manager,
        IMapper mapper)
    {
        _manager = manager;
        _mapper = mapper;
    }

    public async Task<IEnumerable<OrderDto>> GetAllOrdersAsync()
    {
        var ordersModels = await _manager.OrdersRepository.Get()
            .AsNoTracking()

            .ToListAsync();

        var orders = ordersModels.Select(order => _mapper.Map<OrderDto>(order));

        foreach (var order in ordersModels)
        {
            var orderItems = await _manager.OrderItemsRepository.Get()
                .AsNoTracking()
                .Where(x => x.OrderId == order.Id)
                .ToListAsync();

            order.OrderItems = new List<OrderItem>();
            order.OrderItems.AddRange(orderItems);
        }

        return orders;
    }

    public async Task<OrderDto> GetOrderById(int id)
    {
        var order = await _manager.OrdersRepository.Get()
            .AsNoTracking()
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync();

        var orderDto = _mapper.Map<OrderDto>(order);

        return orderDto;
    }

    public async Task<OrderDto> AddOrderAsync(OrderDto dto)
    {
        var model = _mapper.Map<Order>(dto);

        var created = _manager.OrdersRepository.Create(model);
        await _manager.SaveAsync();

        var createdDto = _mapper.Map<OrderDto>(created);

        return createdDto;
    }

    public async Task<OrderDto> DeleteOrderAsync(int id)
    {
        var order = await _manager.OrdersRepository.Get()
            .AsNoTracking()
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync();

        _manager.OrdersRepository.Delete(order);
        await _manager.SaveAsync();

        var deletedDto = _mapper.Map<OrderDto>(order);

        return deletedDto;
    }
}
