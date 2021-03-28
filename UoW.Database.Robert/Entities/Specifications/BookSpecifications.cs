namespace UoW.Database.Robert.Entities.Specifications
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public static class BookSpecifications
    {
        public static void Configure(this EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).ValueGeneratedOnAdd();

            builder.Property(b => b.Title)
                .HasMaxLength(100)
                .HasColumnType("varchar(100)")
                .IsRequired(true);

            builder.Property(b => b.Description)
                .HasMaxLength(500)
                .HasColumnType("varchar(500)")
                .IsRequired(false);

            builder.Property(b => b.AboutBook)
                .HasMaxLength(2000)
                .HasColumnType("nvarchar(2000)")
                .IsRequired(false);

            builder.Property(b => b.EbookUrl)
                .HasMaxLength(100)
                .HasColumnType("varchar(100)")
                .IsRequired(false);

            builder.Property(b => b.Isbn)
                .HasMaxLength(25)
                .HasColumnType("varchar(25)")
                .IsRequired(true);

            builder.Property(b => b.Edition)
                .HasMaxLength(4)
                .HasColumnType("char(4)")
                .IsRequired(true);

            builder.Property(b => b.DateOfPublish)
                .HasColumnType("datetime2");

            builder.HasIndex(b => new
            {
                b.PublisherId,
                b.Title
            }).IsUnique();

            builder.HasIndex(b => b.Isbn).IsUnique();

            builder
                .HasOne(b => b.Publisher)
                .WithMany(p => p.Books)
                .HasForeignKey(b => b.PublisherId);
        }
    }
}
