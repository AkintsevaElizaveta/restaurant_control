using System.Net;
using Microsoft.AspNetCore.Mvc;
using RestaurantControl.Core.Services.MenuCategories;
using RestaurantControl.Models.Restaurant;
using Swashbuckle.AspNetCore.Annotations;

namespace RestaurantControl.Api.Controllers;

[ApiController]
[Route("categories")]
public class MenuCategoriesController : ControllerBase
{
    private readonly IMenuCategoryService _menuCategoryService;

    public MenuCategoriesController(IMenuCategoryService menuCategoryService)
    {
        _menuCategoryService = menuCategoryService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<MenuCategoryDto>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [SwaggerOperation(Summary = "Get all categories")]
    public async Task<IActionResult> GetAllMenuCategories()
    {
        try
        {
            var res = await _menuCategoryService.GetAllMenuCategoriesAsync();
            return Ok(res);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Failed to get categories");
        }
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(MenuCategoryDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [SwaggerOperation(Summary = "Get category by Id")]
    public async Task<IActionResult> GetMenuCategoryById(int id)
    {
        try
        {
            var res = await _menuCategoryService.GetMenuCategoryById(id);
            return Ok(res);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Failed to get category");
        }
    }

    [HttpPost]
    [ProducesResponseType(typeof(MenuCategoryDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [SwaggerOperation(Summary = "Post category")]
    public async Task<IActionResult> PostMenuCategory([FromBody] MenuCategoryDto menuCategory)
    {
        try
        {
            var res = await _menuCategoryService.AddMenuCategoryAsync(menuCategory);
            return Ok(res);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Failed to post category");
        }
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(MenuCategoryDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [SwaggerOperation(Summary = "Delete category by Id")]
    public async Task<IActionResult> DeleteMenuCategory(int id)
    {
        try
        {
            var res = await _menuCategoryService.DeleteMenuCategoryAsync(id);
            return Ok(res);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Failed to delete category");
        }
    }
}
