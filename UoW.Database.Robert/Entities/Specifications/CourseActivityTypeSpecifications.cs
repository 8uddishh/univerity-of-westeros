namespace UoW.Database.Robert.Entities.Specifications
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public static class CourseActivityTypeSpecifications
    {
        public static void Configure(this EntityTypeBuilder<CourseActivityType> builder)
        {
            builder.HasKey(cat => cat.Id);
            builder.Property(cat => cat.Id).ValueGeneratedOnAdd();

            builder.Property(cat => cat.Name)
                .HasMaxLength(200)
                .HasColumnType("varchar(200)")
                .IsRequired(true);

            builder.Property(cat => cat.Description)
                .HasMaxLength(400)
                .HasColumnType("varchar(400)")
                .IsRequired(false);

            builder.HasIndex(cat => cat.Name).IsUnique();
        }
    }
}
