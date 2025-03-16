using UserActivities.Core.Models;

namespace UserActivities.Core.Interfaces
{
    public interface IUserActivitiesRepository
    {
        Task<UserActivity> AddUserActivityAsync(UserActivity userActivity);
    }
}
