namespace RestaurantControl.Core.DataAccess.DbModels;

public abstract class EntityInfo
{
    public int Id { get; set; }

    public int CreatedById { get; set; }

    public DateTimeOffset CreatedDate { get; set; }

    public int ModifiedById { get; set; }

    public DateTimeOffset ModifiedDate { get; set; }
}
