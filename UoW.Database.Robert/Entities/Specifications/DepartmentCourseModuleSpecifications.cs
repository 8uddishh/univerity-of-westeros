namespace UoW.Database.Robert.Entities.Specifications
{
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public static class DepartmentCourseModuleSpecifications
    {
        public static void Configure(this EntityTypeBuilder<DepartmentCourseModule> builder)
        {
            builder.HasKey(dcm => dcm.Id);
            builder.Property(dcm => dcm.Id).ValueGeneratedOnAdd();

            builder.HasIndex(dcm => new
            {
                dcm.DepartmentCourseId,
                dcm.CourseModuleTypeId
            }).IsUnique(true);

            builder
                .HasOne(dcm => dcm.DepartmentCourse)
                .WithMany(dc => dc.DepartmentCourseModules)
                .HasForeignKey(dcm => dcm.DepartmentCourseId);

            builder
                .HasOne(dcm => dcm.CourseModuleType)
                .WithMany(cmt => cmt.DepartmentCourseModules)
                .HasForeignKey(dcm => dcm.CourseModuleTypeId);
        }
    }
}
