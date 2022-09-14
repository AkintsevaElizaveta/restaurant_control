using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestaurantControl.Core.DataAccess.DbModels;
using RestaurantControl.Core.DataAccess.Manager;
using RestaurantControl.Models.Restaurant;

namespace RestaurantControl.Core.Services.Waiters;

public class WaiterService : IWaiterService
{
    private readonly IRestaurantManager _manager;
    private readonly IMapper _mapper;

    public WaiterService(
        IRestaurantManager manager,
        IMapper mapper)
    {
        _manager = manager;
        _mapper = mapper;
    }

    public async Task<IEnumerable<WaiterDto>> GetAllWaitersAsync()
    {
        var waitersModels = await _manager.WaitersRepository.Get()
            .AsNoTracking()

            .ToListAsync();

        var waiters = waitersModels.Select(waiter => _mapper.Map<WaiterDto>(waiter));

        return waiters;
    }

    public async Task<WaiterDto> GetWaiterById(int id)
    {
        var waiter = await _manager.WaitersRepository.Get()
            .AsNoTracking()
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync();

        var waiterDto = _mapper.Map<WaiterDto>(waiter);

        return waiterDto;
    }

    public async Task<WaiterDto> AddWaiterAsync(WaiterDto dto)
    {
        var model = _mapper.Map<Waiter>(dto);

        var created = _manager.WaitersRepository.Create(model);
        await _manager.SaveAsync();

        var createdDto = _mapper.Map<WaiterDto>(created);

        return createdDto;
    }

    public async Task<WaiterDto> DeleteWaiterAsync(int id)
    {
        var waiter = await _manager.WaitersRepository.Get()
            .AsNoTracking()
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync();

        _manager.WaitersRepository.Delete(waiter);
        await _manager.SaveAsync();

        var deletedDto = _mapper.Map<WaiterDto>(waiter);

        return deletedDto;
    }
}
