using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
                try
                {
                    var addedActivity = await userActivitiesService.AddUserActivityAsync(newUserActivityDto);

                    return Results.Ok(addedActivity);
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    return Results.Problem(title: "Concurrency conflict.", detail: ex.Message, statusCode: 401);
                }
                catch (DbUpdateException ex)
                {
                    return Results.Problem(title: "Database update error.", detail: ex.Message, statusCode: 500);
                }
                catch (OperationCanceledException ex)
                {
                    return Results.Problem(title: "Operation canceled.", detail: ex.Message, statusCode: 409);
                }
            })
            .WithName("AddUserActivity")
            .WithOpenApi();

            app.Run();
        }
    }
}
