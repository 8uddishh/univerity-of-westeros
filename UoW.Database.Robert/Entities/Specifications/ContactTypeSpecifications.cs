namespace UoW.Database.Robert.Entities.Specifications
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public static class ContactTypeSpecifications
    {
        public static void Configure(this EntityTypeBuilder<ContactType> builder)
        {
            builder.HasKey(ct => ct.Id);
            builder.Property(ct => ct.Id).ValueGeneratedOnAdd();
            builder.Property(ct => ct.Name)
                .HasMaxLength(200)
                .HasColumnType("varchar(200)")
                .IsRequired(true);
            builder.Property(ct => ct.Name)
                .HasMaxLength(400)
                .HasColumnType("varchar(400)")
                .IsRequired(false);
        }
    }
}
