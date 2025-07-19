namespace Job.Application.Entities
{
    public record PositionEntity(
        string Title,
        string Description,
        string Location,
        string Status,
        int RecruiterId,
        int DepartmentId,
        decimal Budget,
        int? Id,
        DateTime? ClosingDate
    );
}
