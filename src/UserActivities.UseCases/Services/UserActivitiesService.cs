using UserActivities.Core.Interfaces;
using UserActivities.UseCases.Dto;
using UserActivities.UseCases.Mapping;

namespace UserActivities.UseCases.Services
{
    public class UserActivitiesService
    {
        private readonly IUserActivitiesRepository _userActivitiesRepository;

        public UserActivitiesService(IUserActivitiesRepository userActivitiesRepository)
        {
            _userActivitiesRepository = userActivitiesRepository;
        }

        public async Task<UserActivityDto> AddUserActivityAsync(NewUserActivityDto newUserActivityDto)
        {
            var userActivity = newUserActivityDto.FromDto();

            var addedActivity = await _userActivitiesRepository.AddUserActivityAsync(userActivity);

            return addedActivity.ToDto();
        }
    }
}
