using System.Net;
using Microsoft.AspNetCore.Mvc;
using RestaurantControl.Core.Exceptions;
using RestaurantControl.Core.Services.Users;
using RestaurantControl.Models.Auth;
using Swashbuckle.AspNetCore.Annotations;

namespace RestaurantControl.Api.Controllers;

[ApiController]
[Route("signup")]
public class SignupController : ControllerBase
{
    private readonly IUsersService _usersService;

    public SignupController(IUsersService usersService)
    {
        _usersService = usersService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(UserInfoDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [SwaggerOperation(Summary = "Sign up")]
    public async Task<IActionResult> Signup([FromBody] LoginDto loginDto)
    {
        try
        {
            var result = await _usersService.SignUpAsync(loginDto);

            if (result == null)
            {
                BadRequest();
            }

            return Ok(result);
        }
        catch (AuthorizationException)
        {
            return BadRequest($"Username {loginDto.Login} already exists");
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Failed to sign up, error: {e.Message}");
        }
    }
}
