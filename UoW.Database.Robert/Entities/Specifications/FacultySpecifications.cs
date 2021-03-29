namespace UoW.Database.Robert.Entities.Specifications
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public static class FacultySpecifications
    {
        public static void Configure(this EntityTypeBuilder<Faculty> builder)
        {
            builder.ToTable("Faculties");
            builder.HasKey(f => f.Id);
            builder.Property(f => f.Id).ValueGeneratedOnAdd();

            builder.Property(f => f.FirstName)
                .HasMaxLength(100)
                .HasColumnType("varchar(100)")
                .IsRequired(true);
            builder.Property(f => f.LastName)
                .HasMaxLength(100)
                .HasColumnType("varchar(100)")
                .IsRequired(true);
            builder.Property(f => f.MiddleName)
                .HasMaxLength(100)
                .HasColumnType("varchar(100)")
                .IsRequired(false);
            builder.Property(f => f.Prefix)
                .HasMaxLength(10)
                .HasColumnType("varchar(10)")
                .IsRequired(false);
            builder.Property(f => f.Suffix)
                .HasMaxLength(10)
                .HasColumnType("varchar(10)")
                .IsRequired(false);

            builder.Property(f => f.AboutFaculty)
                .HasMaxLength(2000)
                .HasColumnType("nvarchar(2000)")
                .IsRequired(false);

            builder.Property(f => f.DateOfBirth)
                .HasColumnType("datetime2");

            builder.Property(f => f.DateOfJoin)
                .HasColumnType("datetime2");

            builder.Property(f => f.Gender)
                .HasMaxLength(2)
                .HasColumnType("char(2)")
                .IsRequired(true);

            builder
                .HasCheckConstraint("CK_Faculty_Gender", "[Gender] = 'M' OR [Gender] = 'F' OR [Gender] = 'I'");

            builder
                .HasOne(f => f.FacultyType)
                .WithMany(ft => ft.Faculties)
                .HasForeignKey(f => f.FacultyTypeId);

            builder
                .HasOne(f => f.PrimaryDepartment)
                .WithMany(d => d.PrimaryFaculties)
                .HasForeignKey(f => f.PrimaryDepartmentId);
        }
    }
}
