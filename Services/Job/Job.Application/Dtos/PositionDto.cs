namespace Job.Application.Dtos
{
    public record PositionDto(
        int id,
        string Title,
        string Description,
        string Location,
        string Status,
        int RecruiterId,
        int DepartmentId,
        decimal Budget,
        DateTime? ClosingDate
    );
}
