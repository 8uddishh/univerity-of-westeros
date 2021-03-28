namespace UoW.Database.Robert.Entities.Specifications
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public static class CourseSpecifications
    {
        public static void Configure(this EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.Property(c => c.Code)
                .HasMaxLength(200)
                .HasColumnType("varchar(50)")
                .IsRequired(true);

            builder.Property(c => c.Title)
                .HasMaxLength(400)
                .HasColumnType("varchar(200)")
                .IsRequired(true);

            builder.HasIndex(c => c.Code).IsUnique();

            builder
                .HasOne(c => c.CourseCategoryType)
                .WithMany(cct => cct.Courses)
                .HasForeignKey(c => c.CourseCategoryTypeId);
        }
    }
}
