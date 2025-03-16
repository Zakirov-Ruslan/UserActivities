using UserActivities.Core.Models;
using UserActivities.Core.ValueObjects;
using UserActivities.UseCases.Dto;

namespace UserActivities.UseCases.Mapping
{
    public static class Mapping
    {
        public static MouseMovement FromDto(this MouseMovementDto mouseMovementDto)
        {
            return new MouseMovement()
            {
                X = mouseMovementDto.X,
                Y = mouseMovementDto.Y,
                Time = mouseMovementDto.Time
            };
        }

        public static UserActivity FromDto(this NewUserActivityDto newUserActivityDto)
        {
            return new UserActivity()
            {
                MouseMoves = newUserActivityDto.MouseMovements.Select(FromDto).ToList()
            };
        }

        public static UserActivityDto ToDto(this UserActivity userActivity)
        {
            return new UserActivityDto(
                userActivity.Id,
                userActivity.MouseMoves.Select(m => new MouseMovementDto(m.X, m.Y, m.Time)).ToList()
            );
        }
    }
}
