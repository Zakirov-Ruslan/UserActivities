using Microsoft.EntityFrameworkCore;
using UserActivities.Core.Models;
using System.Reflection;

namespace UserActivities.Infrastructure.Data
{
    public class UserActivitiesDbContext(DbContextOptions<UserActivitiesDbContext> options) : DbContext(options)
    {
        public DbSet<UserActivity> UserActivities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
