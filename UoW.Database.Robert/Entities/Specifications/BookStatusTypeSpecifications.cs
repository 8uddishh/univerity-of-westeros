namespace UoW.Database.Robert.Entities.Specifications
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public static class BookStatusTypeSpecifications
    {
        public static void Configure(this EntityTypeBuilder<BookStatusType> builder)
        {
            builder.HasKey(bst => bst.Id);
            builder.Property(bst => bst.Id)
                .ValueGeneratedNever();

            builder.Property(bst => bst.Name)
                .HasMaxLength(200)
                .HasColumnType("varchar(200)")
                .IsRequired(true);

            builder.Property(bst => bst.Description)
                .HasMaxLength(400)
                .HasColumnType("varchar(400)")
                .IsRequired(false);
        }
    }
}
