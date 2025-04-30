using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    /// <summary>
    /// Mapeamento EF Core para a entidade SaleItem.
    /// </summary>
    public class SaleItemConfiguration : IEntityTypeConfiguration<SaleItem>
    {
        public void Configure(EntityTypeBuilder<SaleItem> builder)
        {
            builder.ToTable("SaleItems");

            // PK e geração de ID
            builder.HasKey(si => si.Id);
            builder.Property(si => si.Id)
                   .HasColumnType("uuid")
                   .HasDefaultValueSql("gen_random_uuid()");

            // FK para Sale
            builder.Property<Guid>("SaleId")
                   .HasColumnType("uuid")
                   .IsRequired();

            // Dados desnormalizados do produto
            builder.Property(si => si.ProductId)
                   .HasColumnType("uuid")
                   .IsRequired();

            builder.Property(si => si.ProductTitle)
                   .HasMaxLength(255)
                   .IsRequired();

            builder.Property(si => si.UnitPrice)
                   .HasColumnType("numeric(18,2)")
                   .IsRequired();

            builder.Property(si => si.Quantity)
                   .HasColumnType("integer")
                   .IsRequired();

            builder.Property(si => si.Discount)
                   .HasColumnType("numeric(18,2)")
                   .IsRequired();

            // Valores calculados não precisam de coluna para TotalItemAmount e ItemTotalAfterDiscount
            // Coluna de cancelamento
            builder.Property(si => si.IsCancelled)
                   .HasColumnType("boolean")
                   .IsRequired();

            // Auditoria
            builder.Property<DateTime>("CreatedAt")
                   .HasColumnType("timestamp with time zone")
                   .IsRequired();

            builder.Property<DateTime?>("UpdatedAt")
                   .HasColumnType("timestamp with time zone");
        }
    }
}
