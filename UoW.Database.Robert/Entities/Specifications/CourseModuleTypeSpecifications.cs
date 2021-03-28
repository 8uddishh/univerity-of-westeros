namespace UoW.Database.Robert.Entities.Specifications
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public static class CourseModuleTypeSpecifications
    {
        public static void Configure(this EntityTypeBuilder<CourseModuleType> builder)
        {
            builder.HasKey(cmt => cmt.Id);
            builder.Property(cmt => cmt.Id).ValueGeneratedOnAdd();

            builder.Property(cmt => cmt.Name)
                .HasMaxLength(200)
                .HasColumnType("varchar(200)")
                .IsRequired(true);

            builder.Property(cmt => cmt.Description)
                .HasMaxLength(400)
                .HasColumnType("varchar(400)")
                .IsRequired(false);

            builder.HasIndex(cmt => cmt.Name).IsUnique();
        }
    }
}
