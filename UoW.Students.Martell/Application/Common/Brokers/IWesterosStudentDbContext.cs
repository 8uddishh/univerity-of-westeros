namespace UoW.Students.Martell.Application.Common.Brokers
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Infrastructure;
    using System;
    using System.Threading.Tasks;
    using UoW.Students.Martell.Domains.Entities;

    public interface IWesterosStudentDbContext : IDisposable
    {
        DbSet<Course> Courses { get; set; }
        DbSet<Student> Students { get; set; }
        DbSet<StudentCourse> StudentCourses { get; set; }
        DbSet<StudentStatusType> StudentStatusTypes { get; set; }

        DatabaseFacade Database { get; }
        Task SaveChangesAsync();
    }
}
