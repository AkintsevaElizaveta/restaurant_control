using RestaurantControl.Models.Restaurant;

namespace RestaurantControl.Core.Services.Tables;

public interface ITableService
{
    Task<IEnumerable<TableDto>> GetAllTablesAsync();

    Task<TableDto> GetTableById(int id);

    Task<TableDto> AddTableAsync(TableDto dto);
}
