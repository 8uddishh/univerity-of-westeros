namespace UoW.Students.Martell.Infrastructure.Persistence.Specifications
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using UoW.Students.Martell.Domains.Entities;

    public static class StudentStatusTypeSpecifications
    {
        public static void Configure(this EntityTypeBuilder<StudentStatusType> builder)
        {
            builder.HasKey(sst => sst.Id);
            builder.Property(sst => sst.Id)
                .ValueGeneratedNever();

            builder.Property(sst => sst.Name)
                .HasMaxLength(200)
                .HasColumnType("varchar(200)")
                .IsRequired(true);

            builder.Property(sst => sst.Description)
                .HasMaxLength(400)
                .HasColumnType("varchar(400)")
                .IsRequired(false);

            builder.HasIndex(sst => sst.Name).IsUnique();
        }
    }
}
