using Microsoft.EntityFrameworkCore;
using UserActivities.Core.Models;
using UserActivities.Core.ValueObjects;
using UserActivities.Infrastructure.Data;
using UserActivities.Infrastructure.Data.Repositories;

namespace UserActivities.Infrastructure.UnitTests
{
    public class UserActivityRepositoryTests
    {
        private readonly DbContextOptions<UserActivitiesDbContext> _dbContextOptions;

        public UserActivityRepositoryTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<UserActivitiesDbContext>()
                .UseInMemoryDatabase(databaseName: "UnitTestsDatabase")
                .Options;
        }

        [Fact]
        public async Task AddUserActivityAsync_ShouldSaveEntityToDatabase()
        {
            // Arrange
            var time = DateTime.Now;
            var userActivity = new UserActivity()
            {
                MouseMoves = new List<MouseMovement>()
                {
                    new MouseMovement() {X = 0, Y = 3, Time = time},
                    new MouseMovement() {X = 1, Y = 2, Time = time},
                    new MouseMovement() {X = 2, Y = 1, Time = time},
                }
            };

            using (var context = new UserActivitiesDbContext(_dbContextOptions))
            {
                var repository = new UserActivityRepository(context);

                // Act
                await repository.AddUserActivityAsync(userActivity);
                await context.SaveChangesAsync();
            }

            // Assert
            using (var context = new UserActivitiesDbContext(_dbContextOptions))
            {
                var savedEntity = await context.UserActivities.
                    Include(u => u.MouseMoves).
                    FirstOrDefaultAsync(u => u.Id == userActivity.Id);

                Assert.NotNull(savedEntity);
                Assert.Equal(userActivity.MouseMoves, savedEntity.MouseMoves);
            }
        }
    }
}