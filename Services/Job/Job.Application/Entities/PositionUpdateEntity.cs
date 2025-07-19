namespace Job.Application.Entities
{
    public record PositionUpdateEntity(
        string? Title,
        string? Description,
        string? Location,
        string? Status,
        int? RecruiterId,
        int? DepartmentId,
        decimal? Budget,
        DateTime? ClosingDate
    );
}
