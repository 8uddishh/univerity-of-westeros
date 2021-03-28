namespace UoW.Database.Robert.Entities.Specifications
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public static class PublisherSpecifications
    {
        public static void Configure(this EntityTypeBuilder<Publisher> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Name)
                .HasMaxLength(200)
                .HasColumnType("varchar(200)")
                .IsRequired(true);

            builder.Property(p => p.Description)
                .HasMaxLength(400)
                .HasColumnType("varchar(400)")
                .IsRequired(false);

            builder.HasIndex(p => p.Name).IsUnique();
        }
    }
}
