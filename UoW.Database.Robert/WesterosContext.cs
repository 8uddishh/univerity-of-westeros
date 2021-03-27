namespace UoW.Database.Robert
{
    using Microsoft.EntityFrameworkCore;
    using UoW.Database.Robert.Entities;
    using UoW.Database.Robert.Entities.Specifications;

    public class WesterosContext : DbContext 
    {
        public WesterosContext(DbContextOptions<WesterosContext> options) : base(options)
        { }

        public DbSet<ContactType> ContactTypes { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<Batch> Batches { get; set; }
        public DbSet<FacultyType> FacultyTypes { get; set; }
        public DbSet<BookStatusType> BookStatusTypes { get; set; }
        public DbSet<StudentStatusType> StudentStatusTypes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContactType>(b => b.Configure());
            modelBuilder.Entity<Semester>(b => b.Configure());
            modelBuilder.Entity<Batch>(b => b.Configure());
            modelBuilder.Entity<FacultyType>(b => b.Configure());
            modelBuilder.Entity<BookStatusType>(b => b.Configure());
            modelBuilder.Entity<StudentStatusType>(b => b.Configure());
        }
    }
}
