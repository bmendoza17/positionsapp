using Job.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Job.Infrastructure.Data.Configurations
{
    public class PositionConfigurator : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.ToTable("Position");

            builder.HasKey(c => c.Id);
            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(18, 0)");

            builder.Property(e => e.Budget).HasColumnType("numeric(18, 0)");

            builder.Property(e => e.DepartmentId).HasColumnType("numeric(18, 0)");

            builder.Property(e => e.Description).HasMaxLength(100);

            builder.Property(e => e.Location).HasMaxLength(50);

            builder.Property(e => e.RecruiterId).HasColumnType("numeric(18, 0)");

            builder.Property(e => e.Status).HasMaxLength(10);

            builder.Property(e => e.Title).HasMaxLength(50);

            builder.HasOne(d => d.Department).WithMany(p => p.Positions)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Position_Department");

            builder.HasOne(d => d.Recruiter).WithMany(p => p.Positions)
                .HasForeignKey(d => d.RecruiterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Position_Recruiter");
        }
    }
}
