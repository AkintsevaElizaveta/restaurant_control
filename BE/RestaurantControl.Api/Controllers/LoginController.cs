using System.Net;
using System.Security.Authentication;
using Microsoft.AspNetCore.Mvc;
using RestaurantControl.Core.Exceptions;
using RestaurantControl.Core.Services.Users;
using RestaurantControl.Models.Auth;
using Swashbuckle.AspNetCore.Annotations;

namespace RestaurantControl.Api.Controllers;

[ApiController]
[Route("login")]
public class LoginController : ControllerBase
{
    private readonly IUsersService _usersService;

    public LoginController(IUsersService usersService)
    {
        _usersService = usersService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(UserInfoDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [SwaggerOperation(Summary = "LogIn")]
    public async Task<IActionResult> LogIn([FromBody] LoginDto loginDto)
    {
        try
        {
            var result = await _usersService.LogInAsync(loginDto);

            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }
        catch (AuthorizationException)
        {
            return BadRequest("Username or password are incorrect");
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Failed to sign up, error: {e.Message}");
        }
    }
}
