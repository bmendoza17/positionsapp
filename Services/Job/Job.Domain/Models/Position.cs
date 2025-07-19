namespace Job.Domain.Models;

public partial class Position
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Location { get; set; } = null!;

    public string Status { get; set; } = null!;

    public int RecruiterId { get; set; }

    public int DepartmentId { get; set; }

    public decimal Budget { get; set; }

    public DateTime? ClosingDate { get; set; }

    public virtual Department Department { get; set; } = null!;

    public virtual Recruiter Recruiter { get; set; } = null!;
}
