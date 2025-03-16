using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserActivities.Core.Models;

namespace UserActivities.Infrastructure.Data.Configurations
{
    public class UserActivitiesConfiguration : IEntityTypeConfiguration<UserActivity>
    {
        public void Configure(EntityTypeBuilder<UserActivity> builder)
        {
            builder.HasKey(u => u.Id);

            builder.OwnsMany(
                post => post.MouseMoves, ownedNavigationBuilder =>
                {
                    ownedNavigationBuilder.ToJson();
                }
            );
        }
    }
}
