namespace UoW.Database.Robert.Entities.Specifications
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public static class DepartmentSpecifications
    {
        public static void Configure(this EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Id).ValueGeneratedOnAdd();

            builder.Property(c => c.Name)
                .HasMaxLength(100)
                .HasColumnType("varchar(100)")
                .IsRequired(true);

            builder.Property(c => c.Abbr)
                .HasMaxLength(20)
                .HasColumnType("varchar(20)")
                .IsRequired(true);

            builder.Property(c => c.Description)
                .HasMaxLength(500)
                .HasColumnType("varchar(500)")
                .IsRequired(false);

            builder.Property(c => c.AboutDepartment)
                .HasMaxLength(2000)
                .HasColumnType("nvarchar(2000)")
                .IsRequired(false);

            builder.Property(c => c.WebsiteUrl)
                .HasMaxLength(200)
                .HasColumnType("varchar(200)")
                .IsRequired(false);

            builder.HasIndex(c => c.Abbr).IsUnique();
            builder.HasIndex(c => c.Name).IsUnique();
        }
    }
}
