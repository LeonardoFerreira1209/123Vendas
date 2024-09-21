using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VENDAS.DOMAIN.Entities;

namespace VENDAS.INFRASTRUCTURE.Context.EntityTypeConfigurations;

/// <summary>
/// Configuração da entidade de venda.
/// </summary>
public class SaleEntityTypeConfiguration : IEntityTypeConfiguration<SaleEntity>
{
    /// <summary>
    /// Configura a entidade.
    /// </summary>
    /// <param name="builder"></param>
    public void Configure(EntityTypeBuilder<SaleEntity> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(
            sale => sale.Created)
                .IsRequired();

        builder.Property(
           sale => sale.Status)
               .IsRequired();

        builder.OwnsOne<ClientEntity>(
            s => s.Client).ToTable("Clients");

        builder.OwnsOne<BranchEntity>(
            s => s.Branch).ToTable("Branchs");

        builder.OwnsMany<ProductEntity>(
            s => s.Products).ToTable("Products");
    }
}
