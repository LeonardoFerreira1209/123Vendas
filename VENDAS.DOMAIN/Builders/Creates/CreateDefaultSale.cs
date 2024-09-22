using VENDAS.DOMAIN.Entities;
using VENDAS.DOMAIN.Enums;

namespace VENDAS.DOMAIN.Builders.Creates;

/// <summary>
/// Criado de venda padrão.
/// </summary>
public static class CreateDefaultSale
{
    /// <summary>
    /// Cria uma entidade de Sale.
    /// </summary>
    /// <param name="client"></param>
    /// <param name="branch"></param>
    /// <param name="products"></param>
    /// <returns></returns>
    public static SaleEntity Create(ClientEntity client,
            BranchEntity branch, IEnumerable<ProductEntity> products) => 
        new SaleBuilder()
            .AddCreated()
            .AddStatus(StatusVenda.NaoCancelado)
            .AddClient(client)
            .AddBranch(branch)
            .AddProducts(products)
            .Builder();
}
