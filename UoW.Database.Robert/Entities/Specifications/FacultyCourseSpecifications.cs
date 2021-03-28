namespace UoW.Database.Robert.Entities.Specifications
{
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public static class FacultyCourseSpecifications
    {
        public static void Configure(this EntityTypeBuilder<FacultyCourse> builder)
        {
            builder.HasKey(fc => fc.Id);
            builder.Property(fc => fc.Id).ValueGeneratedOnAdd();

            builder.HasIndex(fc => new
            {
                fc.CourseId,
                fc.FacultyId
            }).IsUnique();

            builder
                .HasOne(fc => fc.Course)
                .WithMany(c => c.FacultyCourses)
                .HasForeignKey(fc => fc.CourseId);

            builder
                 .HasOne(fc => fc.Faculty)
                 .WithMany(s => s.FacultyCourses)
                 .HasForeignKey(fc => fc.FacultyId);
        }
    }
}
