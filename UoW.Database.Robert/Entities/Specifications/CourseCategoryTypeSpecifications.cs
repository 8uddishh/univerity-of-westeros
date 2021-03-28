namespace UoW.Database.Robert.Entities.Specifications
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public static class CourseCategoryTypeSpecifications
    {
        public static void Configure(this EntityTypeBuilder<CourseCategoryType> builder)
        {
            builder.HasKey(cct => cct.Id);
            builder.Property(cct => cct.Id).ValueGeneratedOnAdd();

            builder.Property(cct => cct.Name)
                .HasMaxLength(200)
                .HasColumnType("varchar(200)")
                .IsRequired(true);

            builder.Property(cct => cct.Description)
                .HasMaxLength(400)
                .HasColumnType("varchar(400)")
                .IsRequired(false);

            builder.HasIndex(cct => cct.Name).IsUnique();
        }
    }
}
