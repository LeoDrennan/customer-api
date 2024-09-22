using Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntityTypeConfigurations;

public class CustomerEntityTypeConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        // Columns
        builder.Property(e => e.Id)
            .ValueGeneratedOnAdd();

        builder.Property(e => e.FirstName)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.LastName)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.Email)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.PhoneNumber)
            .HasMaxLength(100);

        builder.Property(e => e.Created)
            .ValueGeneratedOnAdd()
            .HasDefaultValueSql("(UTC_TIMESTAMP)");
    }
}
