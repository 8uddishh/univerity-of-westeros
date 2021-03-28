namespace UoW.Database.Robert.Entities.Specifications
{
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public static class BookAuthorSpecifications
    {
        public static void Configure(this EntityTypeBuilder<BookAuthor> builder)
        {
            builder.HasKey(ba => ba.Id);
            builder.Property(ba => ba.Id).ValueGeneratedOnAdd();

            builder
                .HasOne(ba => ba.Author)
                .WithMany(a => a.BookAuthors)
                .HasForeignKey(ba => ba.AuthorId);

            builder
                .HasOne(ba => ba.Book)
                .WithMany(b => b.BookAuthors)
                .HasForeignKey(ba => ba.BookId);
        }
    }
}
