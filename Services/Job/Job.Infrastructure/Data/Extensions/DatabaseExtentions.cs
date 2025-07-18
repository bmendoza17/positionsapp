using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Job.Infrastructure.Data.Extensions
{
    public static class DatabaseExtentions
    {
        public static async Task InitialiseDatabaseAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<HikruDbContext>();

            if (context.Database.GetMigrations().Count() > 0)
            {
                context.Database.MigrateAsync().GetAwaiter().GetResult();
            }

            await SeedAsync(context);
        }

        private static async Task SeedAsync(HikruDbContext context)
        {
            await SeedRecruitersAsync(context);
            await SeedDepartmentsAsync(context);
            await SeedPositionsAsync(context);
        }

        private static async Task SeedRecruitersAsync(HikruDbContext context)
        {
            if (!await context.Recruiters.AnyAsync())
            {
                await context.Recruiters.AddRangeAsync(InitialData.Recruiters);
                await context.SaveChangesAsync();
            }
        }

        private static async Task SeedDepartmentsAsync(HikruDbContext context)
        {
            if (!await context.Departments.AnyAsync())
            {
                await context.Departments.AddRangeAsync(InitialData.Departments);
                await context.SaveChangesAsync();
            }
        }

        private static async Task SeedPositionsAsync(HikruDbContext context)
        {
            if (!await context.Positions.AnyAsync())
            {
                await context.Positions.AddRangeAsync(InitialData.Positions);
                await context.SaveChangesAsync();
            }
        }
    }
}