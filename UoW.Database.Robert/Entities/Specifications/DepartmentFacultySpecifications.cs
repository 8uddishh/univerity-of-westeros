namespace UoW.Database.Robert.Entities.Specifications
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public static class DepartmentFacultySpecifications
    {
        public static void Configure(this EntityTypeBuilder<DepartmentFaculty> builder)
        {
            builder.HasKey(df => df.Id);
            builder.Property(df => df.Id).ValueGeneratedOnAdd();

            builder.HasIndex(df => new
            {
                df.DepartmentId,
                df.FacultyId
            }).IsUnique(true);

            builder
                .HasOne(df => df.Department)
                .WithMany(d => d.DepartmentFaculties)
                .HasForeignKey(df => df.DepartmentId);

            builder
                .HasOne(df => df.Faculty)
                .WithMany(f => f.DepartmentFaculties)
                .HasForeignKey(df => df.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict); 
        }
    }
}
