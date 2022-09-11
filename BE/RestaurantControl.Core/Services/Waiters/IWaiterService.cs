using RestaurantControl.Models.Restaurant;

namespace RestaurantControl.Core.Services.Waiters;

public interface IWaiterService
{
    public Task<IEnumerable<WaiterDto>> GetAllWaitersAsync();

    public Task<WaiterDto> GetWaiterById(int id);

    public Task<WaiterDto> AddWaiterAsync(WaiterDto dto);

    public Task<WaiterDto> DeleteWaiterAsync(int id);
}
