namespace UoW.Database.Robert.Entities.Specifications
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public static class BatchSpecifications
    {
        public static void Configure(this EntityTypeBuilder<Batch> builder)
        {
            builder.ToTable("Batches");
            builder.HasKey(bt => bt.Id);
            builder.Property(bt => bt.Id).ValueGeneratedOnAdd();

            builder.Property(bt => bt.EndYear)
                .IsRequired(true);

            builder.Property(bt => bt.Description)
                .HasMaxLength(400)
                .HasColumnType("varchar(400)")
                .IsRequired(false);

            builder.HasIndex(bt => bt.EndYear).IsUnique();
        }
    }
}
