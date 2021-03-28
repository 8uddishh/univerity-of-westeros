namespace UoW.Database.Robert.Entities.Specifications
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public static class CourseSyllabusActivitySpecifications
    {
        public static void Configure(this EntityTypeBuilder<CourseSyllabusActivity> builder)
        {
            builder.ToTable("CourseSyllabusActivities");

            builder.HasKey(ca => ca.Id);
            builder.Property(ca => ca.Id).ValueGeneratedOnAdd();

            builder.Property(ca => ca.Title)
                .HasMaxLength(200)
                .HasColumnType("varchar(200)")
                .IsRequired(true);

            builder.Property(ca => ca.Description)
                .HasMaxLength(400)
                .HasColumnType("varchar(600)")
                .IsRequired(true);

            builder.HasIndex(ca => new
            {
                ca.Title,
                ca.CourseActivityTypeId,
                ca.CourseSyllabusId 
            }).IsUnique();

            builder
                .HasOne(ca => ca.CourseActivityType)
                .WithMany(c => c.CourseActivities)
                .HasForeignKey(ca => ca.CourseActivityTypeId);

            builder
                .HasOne(ca => ca.CourseSyllabus)
                .WithMany(cs => cs.CourseActivities)
                .HasForeignKey(ca => ca.CourseSyllabusId);
        }
    }
}
