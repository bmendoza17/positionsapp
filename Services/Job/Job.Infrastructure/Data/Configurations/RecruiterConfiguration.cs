using Job.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Job.Infrastructure.Data.Configurations
{
    public class RecruiterConfiguration : IEntityTypeConfiguration<Recruiter>
    {
        public void Configure(EntityTypeBuilder<Recruiter> builder)
        {
            builder.ToTable("Recruiter");

            builder.HasKey(c => c.Id);

            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(18, 0)");

            builder.Property(e => e.Email).HasMaxLength(1000);

            builder.Property(e => e.Name).HasMaxLength(100);
        }
    }
}
