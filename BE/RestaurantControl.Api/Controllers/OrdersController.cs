using System.Net;
using Microsoft.AspNetCore.Mvc;
using RestaurantControl.Core.Services.Orders;
using RestaurantControl.Models.Restaurant;
using Swashbuckle.AspNetCore.Annotations;

namespace RestaurantControl.Api.Controllers;

[ApiController]
[Route("orders")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<OrderDto>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [SwaggerOperation(Summary = "Get all orders")]
    public async Task<IActionResult> GetAllOrders()
    {
        try
        {
            var res = await _orderService.GetAllOrdersAsync();
            return Ok(res);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Failed to get orders");
        }
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(OrderDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [SwaggerOperation(Summary = "Get order by Id")]
    public async Task<IActionResult> GetOrderById(int id)
    {
        try
        {
            var res = await _orderService.GetOrderById(id);
            return Ok(res);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Failed to get order");
        }
    }

    [HttpPost]
    [ProducesResponseType(typeof(OrderDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [SwaggerOperation(Summary = "Post order")]
    public async Task<IActionResult> PostOrder([FromBody] OrderDto order)
    {
        try
        {
            var res = await _orderService.AddOrderAsync(order);
            return Ok(res);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Failed to post order");
        }
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(OrderDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [SwaggerOperation(Summary = "Delete order by Id")]
    public async Task<IActionResult> DeleteOrder(int id)
    {
        try
        {
            var res = await _orderService.DeleteOrderAsync(id);
            return Ok(res);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Failed to delete order");
        }
    }
}
