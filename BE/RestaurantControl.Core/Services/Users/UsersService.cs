using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestaurantControl.Core.Authorization;
using RestaurantControl.Core.DataAccess.DbModels;
using RestaurantControl.Core.DataAccess.Manager;
using RestaurantControl.Core.Exceptions;
using RestaurantControl.Models.Auth;

namespace RestaurantControl.Core.Services.Users;

public class UsersService : IUsersService
{
    private readonly IRestaurantManager _manager;
    private readonly IMapper _mapper;
    private readonly IJwtUtils _jwtUtils;

    public UsersService(
        IRestaurantManager manager,
        IMapper mapper,
        IJwtUtils jwtUtils)
    {
        _manager = manager;
        _mapper = mapper;
        _jwtUtils = jwtUtils;
    }

    public async Task<UserInfoDto> LogInAsync(LoginDto loginDto)
    {
        var user = await _manager.UserRepository.Get()
            .Where(x => x.Login == loginDto.Login && x.Password == loginDto.Password)
            .FirstOrDefaultAsync();

        if (user == null)
        {
            throw new AuthorizationException();
        }

        var token = _jwtUtils.GenerateJwtToken(user);

        return new UserInfoDto
        {
            UserId = user.Id,
            UserName = user.Login,
            AccessToken = token
        };
    }

    public async Task<UserInfoDto> SignUpAsync(LoginDto loginDto)
    {
        var hasTheSameLogin = _manager.UserRepository.Get()
            .Any(x => x.Login == loginDto.Login);

        if (hasTheSameLogin)
        {
            throw new AuthorizationException();
        }

        var user = _mapper.Map<User>(loginDto);

        var created = _manager.UserRepository.Create(user);
        await _manager.SaveAsync();

        var token = _jwtUtils.GenerateJwtToken(created);

        return new UserInfoDto
        {
            UserId = created.Id,
            UserName = created.Login,
            AccessToken = token
        };
    }
}
