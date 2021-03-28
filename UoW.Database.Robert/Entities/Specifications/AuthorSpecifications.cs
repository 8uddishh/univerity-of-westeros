namespace UoW.Database.Robert.Entities.Specifications
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public static class AuthorSpecifications
    {
        public static void Configure(this EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();

            builder.Property(a => a.FirstName)
                .HasMaxLength(100)
                .HasColumnType("varchar(100)")
                .IsRequired(true);
            builder.Property(a => a.LastName)
                .HasMaxLength(100)
                .HasColumnType("varchar(100)")
                .IsRequired(true);
            builder.Property(a => a.MiddleName)
                .HasMaxLength(100)
                .HasColumnType("varchar(100)")
                .IsRequired(false);
            builder.Property(a => a.Prefix)
                .HasMaxLength(10)
                .HasColumnType("varchar(10)")
                .IsRequired(false);
            builder.Property(a => a.Suffix)
                .HasMaxLength(10)
                .HasColumnType("varchar(10)")
                .IsRequired(false);

            builder.Property(a => a.AboutAuthor)
                .HasMaxLength(2000)
                .HasColumnType("nvarchar(2000)")
                .IsRequired(false);

            builder.Property(a => a.DateOfBirth)
                .HasColumnType("datetime2");

            builder.Property(a => a.Gender)
                .HasMaxLength(2)
                .HasColumnType("char(2)")
                .IsRequired(true);

            builder
                .HasCheckConstraint("CK_Author_Gender", "[Gender] = 'M' OR [Gender] = 'F' OR [Gender] = 'I'");
        }
    }
}
