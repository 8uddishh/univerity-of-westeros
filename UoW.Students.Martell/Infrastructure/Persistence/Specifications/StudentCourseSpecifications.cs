namespace UoW.Students.Martell.Infrastructure.Persistence.Specifications
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using UoW.Students.Martell.Domain.Entities;

    public static class StudentCourseSpecifications
    {
        public static void Configure(this EntityTypeBuilder<StudentCourse> builder)
        {
            builder.HasKey(sc => sc.Id);
            builder.Property(sc => sc.Id).ValueGeneratedOnAdd();

            builder.Property(sc => sc.Percentage)
                .HasColumnType("decimal(5,2)");

            builder.HasIndex(sc => new
            {
                sc.CourseId,
                sc.StudentId
            }).IsUnique();

            builder
                .HasOne(sc => sc.Course)
                .WithMany(c => c.StudentCourses)
                .HasForeignKey(sc => sc.CourseId);

            builder
                 .HasOne(sc => sc.Student)
                 .WithMany(s => s.StudentCourses)
                 .HasForeignKey(sc => sc.StudentId);
        }
    }
}
