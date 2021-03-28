namespace UoW.Database.Robert.Entities.Specifications
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public static class FacultyAddressContactXrefSpecifications
    {
        public static void Configure(this EntityTypeBuilder<FacultyAddressContactXref> builder)
        {
            builder.HasKey(facx => facx.Id);
            builder.Property(facx => facx.Id)
                .ValueGeneratedNever();

            builder.Property(facx => facx.AddressLine1)
                .HasMaxLength(120)
                .HasColumnType("varchar(120)")
                .IsRequired(true);
            builder.Property(facx => facx.AddressLine2)
                .HasMaxLength(120)
                .HasColumnType("varchar(120)")
                .IsRequired(false);
            builder.Property(facx => facx.AddressLine3)
                .HasMaxLength(120)
                .HasColumnType("varchar(120)")
                .IsRequired(false);

            builder.Property(facx => facx.State)
                .HasMaxLength(2)
                .HasColumnType("char(2)")
                .IsRequired(true);

            builder.Property(facx => facx.Country)
                .HasMaxLength(2)
                .HasColumnType("char(2)")
                .IsRequired(true);

            builder.Property(facx => facx.PostalCode)
                .HasMaxLength(16)
                .HasColumnType("varchar(16)")
                .IsRequired(false);

            builder
                .HasOne(facx => facx.FacultyContact)
                .WithOne(fc => fc.FacultyAddressContactXref)
                .HasForeignKey<FacultyAddressContactXref>(facx => facx.Id);
        }
    }
}
