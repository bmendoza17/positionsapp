namespace Job.API.Models
{
    public class Job
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public string Status { get; set; }

        public int RecruiterId { get; set; }

        public int DepartmentId { get; set; }

        public double Budget { get; set; }

        public DateTime ClosingDate { get; set; }
    }
}
