using dotnetcore_graphql.src.Domain.Configurations;
using dotnetcore_graphql.src.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace dotnetcore_graphql.src.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseModule> CourseModules { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CourseConfiguration());
            modelBuilder.ApplyConfiguration(new CourseModuleConfiguration());
            modelBuilder.ApplyConfiguration(new StudentConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
