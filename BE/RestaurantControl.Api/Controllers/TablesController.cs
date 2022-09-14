using System.Net;
using Microsoft.AspNetCore.Mvc;
using RestaurantControl.Core.Services.Tables;
using RestaurantControl.Models.Restaurant;
using Swashbuckle.AspNetCore.Annotations;

namespace RestaurantControl.Api.Controllers;

[ApiController]
[Route("tables")]
public class TablesController : ControllerBase
{
    private readonly ITableService _tableService;

    public TablesController(ITableService tableService)
    {
        _tableService = tableService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<TableDto>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [SwaggerOperation(Summary = "Get all tables")]
    public async Task<IActionResult> GetAllTables()
    {
        try
        {
            var res = await _tableService.GetAllTablesAsync();
            return Ok(res);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Failed to get tables");
        }
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(TableDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [SwaggerOperation(Summary = "Get table by Id")]
    public async Task<IActionResult> GetTableById(int id)
    {
        try
        {
            var res = await _tableService.GetTableById(id);
            return Ok(res);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Failed to get table");
        }
    }

    [HttpPost]
    [ProducesResponseType(typeof(TableDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [SwaggerOperation(Summary = "Post table by Id")]
    public async Task<IActionResult> PostTable([FromBody] TableDto table)
    {
        try
        {
            var res = await _tableService.AddTableAsync(table);
            return Ok(res);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Failed to post table");
        }
    }
}
