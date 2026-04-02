using Microsoft.EntityFrameworkCore;

namespace WebApplication5.Models
{
    public class ApplicationDbContext :  DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
 : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Student>Students { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                        .HasOne(e => e.Course)
                        .WithMany(d => d.Students)
                        .HasForeignKey(e => e.CourseId);
        }
    }
}
