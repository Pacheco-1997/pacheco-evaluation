using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    /// <summary>
    /// Configuração EF Core para a entidade Branch,
    /// mapeando tabelas, colunas e Owned Types.
    /// </summary>
    public class BranchConfiguration : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.ToTable("Branches");

            // PK e Id como UUID com geração automática
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id)
                   .HasColumnType("uuid")
                   .HasDefaultValueSql("gen_random_uuid()");

            // Nome da filial: varchar(100), not null
            builder.Property(b => b.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            // Owned Type: Address
            builder.OwnsOne(b => b.Address, addr =>
            {
                // Coluna no conceito Owned: prefixa com Address_
                addr.Property(a => a.City)
                    .HasColumnName("Address_City")
                    .IsRequired()
                    .HasMaxLength(100);

                addr.Property(a => a.Street)
                    .HasColumnName("Address_Street")
                    .IsRequired()
                    .HasMaxLength(150);

                addr.Property(a => a.Number)
                    .HasColumnName("Address_Number")
                    .IsRequired();

                addr.Property(a => a.Zipcode)
                    .HasColumnName("Address_ZipCode")
                    .IsRequired()
                    .HasMaxLength(20);

                // Geolocation como nested Owned
                addr.OwnsOne(a => a.Geolocation, geo =>
                {
                    geo.Property(g => g.Lat)
                       .HasColumnName("Address_Geo_Lat")
                       .IsRequired()
                       .HasMaxLength(20);

                    geo.Property(g => g.Long)
                       .HasColumnName("Address_Geo_Long")
                       .IsRequired()
                       .HasMaxLength(20);
                });
            });

            // Campos de auditoria
            builder.Property(b => b.CreatedAt)
                   .HasColumnType("timestamp with time zone")
                   .IsRequired();

            builder.Property(b => b.UpdatedAt)
                   .HasColumnType("timestamp with time zone");
        }
    }
}
