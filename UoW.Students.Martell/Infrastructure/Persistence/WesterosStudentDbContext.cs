namespace UoW.Students.Martell.Infrastructure.Persistence
{
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;
    using UoW.Students.Martell.Application.Common.Brokers;
    using UoW.Students.Martell.Domain.Entities;
    using UoW.Students.Martell.Infrastructure.Persistence.Specifications;

    public class WesterosStudentDbContext : DbContext, IWesterosStudentDbContext
    {
        public WesterosStudentDbContext(DbContextOptions<WesterosStudentDbContext> options)
           : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<StudentStatusType> StudentStatusTypes { get; set; }

        public async Task SaveChangesAsync()
        {
            await base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(b => b.Configure());
            modelBuilder.Entity<Student>(b => b.Configure());
            modelBuilder.Entity<StudentCourse>(b => b.Configure());
            modelBuilder.Entity<StudentStatusType>(b => b.Configure());
        }
    }
}
