namespace RestaurantControl.Models.Auth;

public class UserInfoDto
{
    public int UserId { get; set; }

    public string UserName { get; set; }

    public string AccessToken { get; set; }
}
