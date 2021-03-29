namespace UoW.Database.Robert.Entities.Specifications
{
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public static class DepartmentCourseSpecifications
    {
        public static void Configure(this EntityTypeBuilder<DepartmentCourse> builder)
        {
            builder.HasKey(dc => dc.Id);
            builder.Property(dc => dc.Id).ValueGeneratedOnAdd();

            builder.HasIndex(dc => new
            {
                dc.DepartmentId,
                dc.CourseId,
                dc.SemesterId 
            }).IsUnique(true);

            builder
                .HasOne(dc => dc.Department)
                .WithMany(d => d.DepartmentCourses)
                .HasForeignKey(dc => dc.DepartmentId);

            builder
                .HasOne(dc => dc.Course)
                .WithMany(c => c.DepartmentCourses)
                .HasForeignKey(dc => dc.CourseId);

            builder
                .HasOne(dc => dc.Semester)
                .WithMany(s => s.DepartmentCourses)
                .HasForeignKey(dc => dc.SemesterId);
        }
    }
}
