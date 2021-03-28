namespace UoW.Database.Robert.Entities.Specifications
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public static class CourseSyllabusSpecifications
    {
        public static void Configure(this EntityTypeBuilder<CourseSyllabus> builder)
        {
            builder.ToTable("CourseSyllabi");

            builder.HasKey(cs => cs.Id);
            builder.Property(cs => cs.Id).ValueGeneratedOnAdd();

            builder.Property(cs => cs.Title)
                .HasMaxLength(200)
                .HasColumnType("varchar(200)")
                .IsRequired(true);

            builder.Property(cs => cs.Description)
                .HasMaxLength(400)
                .HasColumnType("varchar(600)")
                .IsRequired(true);

            builder.HasIndex(cs => new
            {
                cs.Title,
                cs.CourseId 
            }).IsUnique();

            builder
                .HasOne(cs => cs.Course)
                .WithMany(c => c.CourseSyllabi)
                .HasForeignKey(cs => cs.CourseId);
        }
    }
}
