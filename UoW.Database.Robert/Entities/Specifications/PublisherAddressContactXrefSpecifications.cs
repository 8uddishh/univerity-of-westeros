namespace UoW.Database.Robert.Entities.Specifications
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public static class PublisherAddressContactXrefSpecifications
    {
        public static void Configure(this EntityTypeBuilder<PublisherAddressContactXref> builder)
        {
            builder.HasKey(pacx => pacx.Id);
            builder.Property(pacx => pacx.Id)
                .ValueGeneratedNever();

            builder.Property(pacx => pacx.AddressLine1)
                .HasMaxLength(120)
                .HasColumnType("varchar(120)")
                .IsRequired(true);
            builder.Property(pacx => pacx.AddressLine2)
                .HasMaxLength(120)
                .HasColumnType("varchar(120)")
                .IsRequired(false);
            builder.Property(pacx => pacx.AddressLine3)
                .HasMaxLength(120)
                .HasColumnType("varchar(120)")
                .IsRequired(false);

            builder.Property(pacx => pacx.State)
                .HasMaxLength(2)
                .HasColumnType("char(2)")
                .IsRequired(true);

            builder.Property(pacx => pacx.Country)
                .HasMaxLength(2)
                .HasColumnType("char(2)")
                .IsRequired(true);

            builder.Property(pacx => pacx.PostalCode)
                .HasMaxLength(16)
                .HasColumnType("varchar(16)")
                .IsRequired(false);

            builder
                .HasOne(pacx => pacx.PublisherContact)
                .WithOne(pc => pc.PublisherAddressContactXref)
                .HasForeignKey<PublisherAddressContactXref>(pacx => pacx.Id);
        }
    }
}
