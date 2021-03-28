namespace UoW.Database.Robert.Entities.Specifications
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public static class PublisherContactSpecifications
    {
        public static void Configure(this EntityTypeBuilder<PublisherContact> builder)
        {
            builder.HasKey(pc => pc.Id);
            builder.Property(pc => pc.Id).ValueGeneratedOnAdd();

            builder.Property(pc => pc.Intel)
                .HasMaxLength(500)
                .HasColumnType("varchar(500)")
                .IsRequired(true);

            builder.HasIndex(pc => new
            {
                pc.PublisherId,
                pc.PublisherContactTypeId,
                pc.Intel
            }).IsUnique();

            builder
                .HasOne(pc => pc.Publisher)
                .WithMany(p => p.PublisherContacts)
                .HasForeignKey(pc => pc.PublisherId);

            builder
                .HasOne(pc => pc.PublisherContactType)
                .WithMany(ct => ct.PublisherContacts)
                .HasForeignKey(pc => pc.PublisherContactTypeId);
        }
    }
}
