namespace UserActivities.UseCases.Dto
{
    public record UserActivityDto(
        int Id,
        List<MouseMovementDto> MouseMovements
    );
}

