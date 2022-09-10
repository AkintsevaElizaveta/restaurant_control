using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestaurantControl.Core.DataAccess.DbModels;
using RestaurantControl.Core.DataAccess.Manager;
using RestaurantControl.Models.Restaurant;

namespace RestaurantControl.Core.Services.Tables;

public class TableService : ITableService
{
    private readonly IRestaurantManager _manager;
    private readonly IMapper _mapper;

    public TableService(
        IRestaurantManager manager,
        IMapper mapper)
    {
        _manager = manager;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TableDto>> GetAllTablesAsync()
    {
        var tablesModels = await _manager.TablesRepository.Get()
            .AsNoTracking()

            .ToListAsync();

        var tables = tablesModels.Select(table => _mapper.Map<TableDto>(table));

        return tables;
    }

    public async Task<TableDto> GetTableById(int id)
    {
        var table = await _manager.TablesRepository.Get()
            .AsNoTracking()
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync();

        var tableDto = _mapper.Map<TableDto>(table);

        return tableDto;
    }

    public Task<TableDto> AddTableAsync(TableDto dto)
    {
        var model = _mapper.Map<Table>(dto);

        var created = _manager.TablesRepository.Create(model);
        var createdDto = _mapper.Map<TableDto>(created);

        return Task.FromResult(createdDto);
    }
}
