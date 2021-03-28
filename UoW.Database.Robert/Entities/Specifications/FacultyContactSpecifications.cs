namespace UoW.Database.Robert.Entities.Specifications
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public static class FacultyContactSpecifications
    {
        public static void Configure(this EntityTypeBuilder<FacultyContact> builder)
        {
            builder.HasKey(fc => fc.Id);
            builder.Property(fc => fc.Id).ValueGeneratedOnAdd();

            builder.Property(pc => pc.Intel)
                .HasMaxLength(500)
                .HasColumnType("varchar(500)")
                .IsRequired(true);

            builder.HasIndex(fc => new
            {
                fc.FacultyId,
                fc.FacultyContactTypeId,
                fc.Intel
            }).IsUnique();

            builder
                .HasOne(fc => fc.Faculty)
                .WithMany(f => f.FacultyContacts)
                .HasForeignKey(fc => fc.FacultyId);

            builder
                .HasOne(fc => fc.FacultyContactType)
                .WithMany(ct => ct.FacultyContacts)
                .HasForeignKey(fc => fc.FacultyContactTypeId);
        }
    }
}
