namespace RestaurantControl.Core.DataAccess.DbModels;

public class MenuItem : EntityInfo
{
    public int? MenuCategoryId { get; set; }

    public string Name { get; set; }

    public string PhotoUrl { get; set; }

    public double Price { get; set; }
}
