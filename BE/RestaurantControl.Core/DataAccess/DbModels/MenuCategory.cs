namespace RestaurantControl.Core.DataAccess.DbModels;

public class MenuCategory : EntityInfo
{
    public string Name { get; set; }

    public List<MenuItem> MenuItems { get; set; }
}
