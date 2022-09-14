using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantControl.Core.Services.Waiters;
using RestaurantControl.Models.Restaurant;
using Swashbuckle.AspNetCore.Annotations;

namespace RestaurantControl.Api.Controllers;

[ApiController]
[Route("waiters")]
[Authorize]
public class WaitersController : ControllerBase
{
    private readonly IWaiterService _waiterService;

    public WaitersController(IWaiterService waiterService)
    {
        _waiterService = waiterService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<WaiterDto>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [SwaggerOperation(Summary = "Get all waiters")]
    public async Task<IActionResult> GetAllWaiters()
    {
        try
        {
            var res = await _waiterService.GetAllWaitersAsync();
            return Ok(res);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Failed to get waiters");
        }
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(WaiterDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [SwaggerOperation(Summary = "Get waiter by Id")]
    public async Task<IActionResult> GetWaiterById(int id)
    {
        try
        {
            var res = await _waiterService.GetWaiterById(id);
            return Ok(res);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Failed to get waiter");
        }
    }

    [HttpPost]
    [ProducesResponseType(typeof(WaiterDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [SwaggerOperation(Summary = "Post waiter")]
    public async Task<IActionResult> PostWaiter([FromBody] WaiterDto waiter)
    {
        try
        {
            var res = await _waiterService.AddWaiterAsync(waiter);
            return Ok(res);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Failed to post waiter");
        }
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(WaiterDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [SwaggerOperation(Summary = "Delete waiter by Id")]
    public async Task<IActionResult> DeleteWaiter(int id)
    {
        try
        {
            var res = await _waiterService.DeleteWaiterAsync(id);
            return Ok(res);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Failed to delete waiter");
        }
    }
}
