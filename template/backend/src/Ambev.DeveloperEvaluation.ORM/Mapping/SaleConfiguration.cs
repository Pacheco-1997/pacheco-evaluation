using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    /// <summary>
    /// Mapeamento EF Core para o agregado Sale.
    /// </summary>
    public class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.ToTable("Sales");

            // Chave primária e geração automática de UUID
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id)
                   .HasColumnType("uuid")
                   .HasDefaultValueSql("gen_random_uuid()");

            // Campos de cabeçalho da venda
            builder.Property(s => s.SaleDate)
                   .HasColumnType("timestamp with time zone")
                   .IsRequired();

            builder.Property(s => s.CustomerId)
                   .HasColumnType("uuid")
                   .IsRequired();

            builder.Property(s => s.CustomerName)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(s => s.BranchId)
                   .HasColumnType("uuid")
                   .IsRequired();

            builder.Property(s => s.BranchName)
                   .HasMaxLength(100)
                   .IsRequired();

            // Totais
            builder.Property(s => s.Subtotal)
                   .HasColumnType("numeric(18,2)")
                   .IsRequired();

            builder.Property(s => s.Total)
                   .HasColumnType("numeric(18,2)")
                   .IsRequired();

            // Flag de cancelamento
            builder.Property(s => s.IsCancelled)
                   .HasColumnType("boolean")
                   .IsRequired();

            // Relacionamento 1:N com SaleItem
            builder.HasMany(s => s.Items)
                   .WithOne()                     // nenhum navigation property inverso
                   .HasForeignKey("SaleId")       // FK na tabela SaleItem
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);  // cascata ao cancelar ou remover venda :contentReference[oaicite:0]{index=0}

            // Auditoria (herdada de BaseEntity)
            builder.Property<DateTime>("CreatedAt")
                   .HasColumnType("timestamp with time zone")
                   .IsRequired();

            builder.Property<DateTime?>("UpdatedAt")
                   .HasColumnType("timestamp with time zone");
        }
    }
}
