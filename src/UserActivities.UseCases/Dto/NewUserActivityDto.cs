namespace UserActivities.UseCases.Dto
{
    public record NewUserActivityDto(
        List<MouseMovementDto> MouseMovements
    );
}
