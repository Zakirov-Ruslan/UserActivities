using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserActivities.Core.Interfaces;
using UserActivities.Infrastructure.Data;
using UserActivities.Infrastructure.Data.Repositories;
using UserActivities.UseCases.Services;

namespace UserActivities.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<UserActivitiesDbContext>(options => {

                options.UseInMemoryDatabase("UserActivityTestDatabase");
            });

            services.AddScoped<IUserActivitiesRepository, UserActivityRepository>();
            services.AddScoped<UserActivitiesService>();

            return services;
        }
    }
}
