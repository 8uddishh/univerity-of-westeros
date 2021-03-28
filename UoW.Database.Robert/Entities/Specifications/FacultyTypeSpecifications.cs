namespace UoW.Database.Robert.Entities.Specifications
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public static class FacultyTypeSpecifications
    {
        public static void Configure(this EntityTypeBuilder<FacultyType> builder)
        {
            builder.HasKey(ft => ft.Id);
            builder.Property(ft => ft.Id).ValueGeneratedOnAdd();

            builder.Property(ft => ft.Name)
                .HasMaxLength(200)
                .HasColumnType("varchar(200)")
                .IsRequired(true);

            builder.Property(ft => ft.Description)
                .HasMaxLength(400)
                .HasColumnType("varchar(400)")
                .IsRequired(false);

            builder.HasIndex(ft => ft.Name).IsUnique();
        }
    }
}
