using Microsoft.EntityFrameworkCore;
using VENDAS.DOMAIN.Entities;
using VENDAS.INFRASTRUCTURE.Context.EntityTypeConfigurations;

namespace VENDAS.INFRASTRUCTURE.Context;

/// <summary>
///  Classe de contexto.
/// </summary>
/// <remarks>
/// ctor
/// </remarks>
/// <param name="options"></param>
public sealed class SaleContext(
    DbContextOptions<SaleContext> options) : DbContext(options)
{
    public DbSet<SaleEntity> Sales => Set<SaleEntity>();

    /// <summary>
    /// On model creating.
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder
           .ApplyConfiguration(new SaleEntityTypeConfiguration());
    }
}
