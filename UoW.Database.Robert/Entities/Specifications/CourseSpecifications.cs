namespace UoW.Database.Robert.Entities.Specifications
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public static class CourseSpecifications
    {
        public static void Configure(this EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(ct => ct.Id);
            builder.Property(ct => ct.Id).ValueGeneratedOnAdd();

            builder.Property(ct => ct.Code)
                .HasMaxLength(200)
                .HasColumnType("varchar(50)")
                .IsRequired(true);

            builder.Property(ct => ct.Title)
                .HasMaxLength(400)
                .HasColumnType("varchar(200)")
                .IsRequired(true);

            builder.HasIndex(ct => ct.Code).IsUnique();

            builder
                .HasOne(ct => ct.CourseCategoryType)
                .WithMany(ctt => ctt.Courses)
                .HasForeignKey(ct => ct.CategoryTypeId);
        }
    }
}
