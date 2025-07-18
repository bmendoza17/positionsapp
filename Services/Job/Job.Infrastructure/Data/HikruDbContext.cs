using System.Reflection;
using Job.Application.Data;
using Job.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Job.Infrastructure.Data
{
    public partial class HikruDbContext : DbContext, IHikruDbContext
    {
        public HikruDbContext()
        {
        }

        public HikruDbContext(DbContextOptions<HikruDbContext> options)
            : base(options)
        {
        }

        public DbSet<Position> Positions => Set<Position>();

        public DbSet<Recruiter> Recruiters => Set<Recruiter>(); 

        public DbSet<Department> Departments => Set<Department>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}
