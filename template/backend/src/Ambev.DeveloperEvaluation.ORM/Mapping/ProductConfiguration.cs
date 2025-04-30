using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            // Primary key
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .HasColumnType("uuid")
                .HasDefaultValueSql("gen_random_uuid()");

            // Properties
            builder.Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(p => p.Description)
                .HasColumnType("text");

            builder.Property(p => p.Category)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.ImageUrl)
                .IsRequired()
                .HasMaxLength(2048);

            builder.Property(p => p.UnitPrice)
                .HasColumnType("numeric(10,2)")
                .IsRequired();

            builder.Property(p => p.RatingRate)
                .HasColumnType("numeric(3,2)");

            builder.Property(p => p.RatingCount)
                .IsRequired();

            // Audit fields
            builder.Property(p => p.CreatedAt)
                .HasColumnType("timestamp with time zone")
                .IsRequired();

            builder.Property(p => p.UpdatedAt)
                .HasColumnType("timestamp with time zone");
        }
    }
}
