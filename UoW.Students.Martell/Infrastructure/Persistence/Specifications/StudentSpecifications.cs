namespace UoW.Students.Martell.Infrastructure.Persistence.Specifications
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using UoW.Students.Martell.Domains.Entities;

    public static class StudentSpecifications
    {
        public static void Configure(this EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).ValueGeneratedOnAdd();

            builder.Property(s => s.FirstName)
                .HasMaxLength(100)
                .HasColumnType("varchar(100)")
                .IsRequired(true);
            builder.Property(s => s.LastName)
                .HasMaxLength(100)
                .HasColumnType("varchar(100)")
                .IsRequired(true);
            builder.Property(s => s.MiddleName)
                .HasMaxLength(100)
                .HasColumnType("varchar(100)")
                .IsRequired(false);
            builder.Property(s => s.Prefix)
                .HasMaxLength(10)
                .HasColumnType("varchar(10)")
                .IsRequired(false);
            builder.Property(s => s.Suffix)
                .HasMaxLength(10)
                .HasColumnType("varchar(10)")
                .IsRequired(false);

            builder.Property(s => s.DateOfBirth)
                .HasColumnType("datetime2");
            builder.Property(s => s.DateOfJoin)
                .HasColumnType("datetime2");

            builder.Property(s => s.Gender)
                .HasMaxLength(2)
                .HasColumnType("char(2)")
                .IsRequired(true);

            builder
                .HasCheckConstraint("CK_Student_Gender", "[Gender] = 'M' OR [Gender] = 'F' OR [Gender] = 'I'");

            builder
               .HasOne(s => s.StudentStatusType)
               .WithMany(sst => sst.Students)
               .HasForeignKey(s => s.StudentStatusTypeId);
        }
    }
}
