using dotnetcore_graphql.src.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dotnetcore_graphql.src.Domain.Configurations
{
    public class CourseModuleConfiguration : IEntityTypeConfiguration<CourseModule>
    {
        public void Configure(EntityTypeBuilder<CourseModule> builder)
        {
            builder.ToTable("course_modules", schema: "public");

            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).HasColumnName("id");
            builder.Property(m => m.Title).HasColumnName("title");
            builder.Property(m => m.Status).HasConversion<string>().HasColumnName("status");
            builder.Property(m => m.EstimatedHours).HasColumnName("estimated_hours");
            builder.Property(m => m.HoursSpent).HasColumnName("hours_spent");

            builder
                .HasOne(m => m.Course)
                .WithMany(c => c.Modules)
                .HasForeignKey(m => m.CourseId);
        }
    }
}
