using Microsoft.AspNetCore.Mvc;
using UserActivities.Infrastructure;
using UserActivities.UseCases.Dto;
using UserActivities.UseCases.Services;

namespace UserActivities.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddInfrastructureServices(builder.Configuration);

            var app = builder.Build();

            app.UseStaticFiles();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.MapPost("api/UserActivities", async ([FromBody] NewUserActivityDto newUserActivityDto, UserActivitiesService userActivitiesService) =>
            {
                var addedActivity = await userActivitiesService.AddUserActivityAsync(newUserActivityDto);

                return Results.Ok(addedActivity);
            })
            .WithName("AddUserActivity")
            .WithOpenApi();

            app.Run();
        }
    }
}
