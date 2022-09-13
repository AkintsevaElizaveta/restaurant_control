using System.Net;
using Microsoft.AspNetCore.Mvc;
using RestaurantControl.Core.Services.MenuItems;
using RestaurantControl.Models.Restaurant;
using Swashbuckle.AspNetCore.Annotations;

namespace RestaurantControl.Api.Controllers;

[ApiController]
[Route("menuitems")]
public class MenuItemsController : ControllerBase
{
    private readonly IMenuItemService _menuItemService;

    public MenuItemsController(IMenuItemService menuItemService)
    {
        _menuItemService = menuItemService;
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(MenuItemDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [SwaggerOperation(Summary = "Get menuitem by Id")]
    public async Task<IActionResult> GetMenuItemById(int id)
    {
        try
        {
            var res = await _menuItemService.GetMenuItemById(id);
            return Ok(res);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Failed to get menuitem");
        }
    }

    [HttpPost]
    [ProducesResponseType(typeof(MenuItemDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [SwaggerOperation(Summary = "Post menuItem")]
    public async Task<IActionResult> PostMenuItem([FromBody] MenuItemDto menuItem)
    {
        try
        {
            var res = await _menuItemService.AddMenuItemAsync(menuItem);
            return Ok(res);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Failed to post menuitem");
        }
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(MenuItemDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [SwaggerOperation(Summary = "Delete menuitem by Id")]
    public async Task<IActionResult> DeleteMenuItem(int id)
    {
        try
        {
            var res = await _menuItemService.DeleteMenuItemAsync(id);
            return Ok(res);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Failed to delete menuitem");
        }
    }
}
