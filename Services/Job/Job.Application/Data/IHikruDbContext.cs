using Job.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Job.Application.Data
{
    public interface IHikruDbContext
    {
        DbSet<Position> Positions { get; }

        DbSet<Recruiter> Recruiters { get; }

        DbSet<Department> Departments { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}