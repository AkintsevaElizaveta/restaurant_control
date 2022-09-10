using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestaurantControl.Core.DataAccess.DbModels;

namespace RestaurantControl.Core.DataAccess.Extensions;

public static class DbContextExtensions
{
    public static void ApplyBaseModelConfiguration<T>(this EntityTypeBuilder<T> typeBuilder)
        where T : EntityInfo
    {
        typeBuilder.HasKey(x => x.Id);
    }
}
