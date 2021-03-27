namespace UoW.Database.Robert.Entities.Specifications
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
        }
    }
}
