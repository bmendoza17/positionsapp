using Job.Domain.Models;

namespace Job.Infrastructure.Data.Extensions
{
    internal class InitialData
    {
        public static IEnumerable<Recruiter> Recruiters =>
        [
            new Recruiter() { Name = "Jose", Email = "jose@enterprise.com" },
            new Recruiter() { Name = "Pamela", Email = "pamela@enterprise.com" }
        ];

        public static IEnumerable<Department> Departments =>
        [
            new Department() { Name = "Software Development", Description = "Developing software solutions" },
            new Department() { Name = "Human Resources", Description = "Managing human resources" },
            new Department() { Name = "Marketing", Description = "Promoting products and services" },
        ];

        public static IEnumerable<Position> Positions => 
            [
                new Position
                {
                    Title = "Software Engineer",
                    Description = "Develop and maintain software applications",
                    Location = "Remote",
                    Status = "Open",
                    RecruiterId = 1,
                    DepartmentId = 1,
                    Budget = 100000,
                    ClosingDate = DateTime.Now.AddMonths(1)
                },
                new Position
                {
                    Title = "HR Manager",
                    Description = "Oversee HR operations and employee relations",
                    Location = "On-site",
                    Status = "Closed",
                    RecruiterId = 2,
                    DepartmentId = 2,
                    Budget = 100000,
                    ClosingDate = DateTime.Now.AddMonths(2)
                }
            ];
    }
}
