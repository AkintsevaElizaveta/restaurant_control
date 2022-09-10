namespace RestaurantControl.Core.DataAccess.DbModels;

public class User : EntityInfo
{
    public string Login { get; set; }

    public string Password { get; set; }
}
