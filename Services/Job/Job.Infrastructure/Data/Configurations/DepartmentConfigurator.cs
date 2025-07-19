using Job.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Job.Infrastructure.Data.Configurations
{
    internal class DepartmentConfigurator : IEntityTypeConfiguration<Department>
    {
        void IEntityTypeConfiguration<Department>.Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("Department");

            builder.HasKey(c => c.Id);
            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(18, 0)");

            builder.Property(e => e.Description).HasMaxLength(1000);

            builder.Property(e => e.Name).HasMaxLength(100);
        }
    }
}
