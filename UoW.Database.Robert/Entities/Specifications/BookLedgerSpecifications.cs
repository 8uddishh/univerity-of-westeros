namespace UoW.Database.Robert.Entities.Specifications
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public static class BookLedgerSpecifications
    {
        public static void Configure(this EntityTypeBuilder<BookLedger> builder)
        {
            builder.HasKey(bl => bl.Id);
            builder.Property(bl => bl.Id).ValueGeneratedOnAdd();

            builder.Property(bl => bl.SerialNumber)
                .HasMaxLength(100)
                .HasColumnType("varchar(100)")
                .IsRequired(true);

            builder.Property(bl => bl.LendedOn)
                .HasColumnType("datetime2");
            builder.Property(bl => bl.DueOn)
                .HasColumnType("datetime2");

            builder
                .HasIndex(bl => bl.SerialNumber)
                .IsUnique(true);

            builder
                .HasOne(bl => bl.Book)
                .WithMany(b => b.BookLedgers)
                .HasForeignKey(bl => bl.BookId);

            builder
                .HasOne(bl => bl.BookStatusType)
                .WithMany(bs => bs.BookLedgers)
                .HasForeignKey(bl => bl.BookStatusTypeId);

            builder
                .HasOne(bl => bl.Student)
                .WithMany(s => s.BookLedgers)
                .HasForeignKey(bl => bl.StudentId);

            builder
                .HasOne(bl => bl.Faculty)
                .WithMany(f => f.BookLedgers)
                .HasForeignKey(bl => bl.FacultyId);
        }
    }
}
