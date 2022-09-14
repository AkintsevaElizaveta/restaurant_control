using System.Net;
using Microsoft.AspNetCore.Mvc;
using RestaurantControl.Core.Services.OrderItems;
using RestaurantControl.Models.Restaurant;
using Swashbuckle.AspNetCore.Annotations;

namespace RestaurantControl.Api.Controllers;

[ApiController]
[Route("orderitems")]
public class OrderItemsController : ControllerBase
{
    private readonly IOrderItemService _orderItemService;

    public OrderItemsController(IOrderItemService orderItemService)
    {
        _orderItemService = orderItemService;
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(OrderItemDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [SwaggerOperation(Summary = "Get orderitem by Id")]
    public async Task<IActionResult> GetOrderItemById(int id)
    {
        try
        {
            var res = await _orderItemService.GetOrderItemById(id);
            return Ok(res);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Failed to get orderitem");
        }
    }

    [HttpPost]
    [ProducesResponseType(typeof(OrderItemDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [SwaggerOperation(Summary = "Post orderitem")]
    public async Task<IActionResult> PostOrderItem([FromBody] OrderItemDto orderItem)
    {
        try
        {
            var res = await _orderItemService.AddOrderItemAsync(orderItem);
            return Ok(res);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Failed to post orderitem");
        }
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(OrderItemDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [SwaggerOperation(Summary = "Get orderitem by Id")]
    public async Task<IActionResult> DeleteWaiter(int id)
    {
        try
        {
            var res = await _orderItemService.DeleteOrderItemAsync(id);
            return Ok(res);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Failed to delete orderitem");
        }
    }
}
