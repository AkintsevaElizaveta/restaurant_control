using RestaurantControl.Core.DataAccess.DbModels;

namespace RestaurantControl.Core.Authorization;

public interface IJwtUtils
{
    string GenerateJwtToken(User user);

    bool ValidateJwtToken(string token);

    int GetUserIdFromToken(string token);
}
