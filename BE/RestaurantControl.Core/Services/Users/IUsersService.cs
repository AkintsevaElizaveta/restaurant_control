using RestaurantControl.Models.Auth;

namespace RestaurantControl.Core.Services.Users;

public interface IUsersService
{
    Task<UserInfoDto> LogInAsync(LoginDto loginDto);

    Task<UserInfoDto> SignUpAsync(LoginDto loginDto);
}
