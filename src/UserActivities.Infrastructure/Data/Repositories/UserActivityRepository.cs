using UserActivities.Core.Interfaces;
using UserActivities.Core.Models;

namespace UserActivities.Infrastructure.Data.Repositories
{
    public class UserActivityRepository : IUserActivitiesRepository
    {
        private readonly UserActivitiesDbContext _dbContext;

        public UserActivityRepository(UserActivitiesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserActivity> AddUserActivityAsync(UserActivity userActivity)
        {
            _dbContext.UserActivities.Add(userActivity);

            await _dbContext.SaveChangesAsync();

            return userActivity;
        }
    }
}
