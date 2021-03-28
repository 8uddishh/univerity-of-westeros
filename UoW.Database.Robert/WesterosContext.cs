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
        
        public DbSet<StudentStatusType> StudentStatusTypes { get; set; }

        // Faculties
        public DbSet<FacultyType> FacultyTypes { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<FacultyCourse> FacultyCourses { get; set; }
        public DbSet<FacultyContact> FacultyContacts { get; set; }
        public DbSet<FacultyAddressContactXref> FacultyAddressContactXrefs { get; set; }

        // Books
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<PublisherContact> PublisherContacts { get; set; }
        public DbSet<PublisherAddressContactXref> PublisherAddressContactXrefs { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookStatusType> BookStatusTypes { get; set; }
        public DbSet<BookLedger> BookLedgers { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }

        // Courses
        public DbSet<CourseCategoryType> CourseCategoryTypes { get; set; }
        public DbSet<CourseActivityType> CourseActivityTypes { get; set; }
        public DbSet<CourseModuleType> CourseModuleTypes { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseSyllabus> CourseSyllabi { get; set; }
        public DbSet<CourseSyllabusActivity> CourseActivities { get; set; }

        // Departments
        public DbSet<Department> Departments { get; set; }

        // Students
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContactType>(b => b.Configure());
            modelBuilder.Entity<Semester>(b => b.Configure());
            modelBuilder.Entity<Batch>(b => b.Configure());
            modelBuilder.Entity<StudentStatusType>(b => b.Configure());

            // Faculties
            modelBuilder.Entity<FacultyType>(b => b.Configure());
            modelBuilder.Entity<Faculty>(b => b.Configure());
            modelBuilder.Entity<FacultyCourse>(b => b.Configure());
            modelBuilder.Entity<FacultyContact>(b => b.Configure());
            modelBuilder.Entity<FacultyAddressContactXref>(b => b.Configure());

            // Books
            modelBuilder.Entity<Publisher>(b => b.Configure());
            modelBuilder.Entity<PublisherContact>(b => b.Configure());
            modelBuilder.Entity<PublisherAddressContactXref>(b => b.Configure());
            modelBuilder.Entity<Book>(b => b.Configure());
            modelBuilder.Entity<BookStatusType>(b => b.Configure());
            modelBuilder.Entity<Author>(b => b.Configure());
            modelBuilder.Entity<BookAuthor>(b => b.Configure());
            modelBuilder.Entity<BookLedger>(b => b.Configure());

            // Courses
            modelBuilder.Entity<CourseCategoryType>(b => b.Configure());
            modelBuilder.Entity<CourseActivityType>(b => b.Configure());
            modelBuilder.Entity<CourseModuleType>(b => b.Configure());
            modelBuilder.Entity<Course>(b => b.Configure());
            modelBuilder.Entity<CourseSyllabus>(b => b.Configure());
            modelBuilder.Entity<CourseSyllabusActivity>(b => b.Configure());

            // Departments
            modelBuilder.Entity<Department>(b => b.Configure());

            // Students
            modelBuilder.Entity<Student>(b => b.Configure());
            modelBuilder.Entity<StudentCourse>(b => b.Configure());
        }
    }
}
