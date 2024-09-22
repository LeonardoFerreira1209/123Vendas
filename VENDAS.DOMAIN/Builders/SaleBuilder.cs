using VENDAS.DOMAIN.Entities;
using VENDAS.DOMAIN.Enums;

namespace VENDAS.DOMAIN.Builders;

/// <summary>
/// Classe de criação de modelo de entidade de Venda.
/// </summary>
public sealed class SaleBuilder
{
    /// <summary>
    /// Private properties.
    /// </summary>
    private DateTime created;
    private DateTime? updated = null;
    private StatusVenda status;
    private ClientEntity client;
    private BranchEntity branch;
    private IEnumerable<ProductEntity> products;

    /// <summary>
    /// Adiciona a data de criação.
    /// </summary>
    /// <param name="created"></param>
    /// <returns></returns>
    public SaleBuilder AddCreated(DateTime? created = null)
    {
        this.created
            = created
            ?? DateTime.Now;

        return this;
    }

    /// <summary>
    /// Adiciona a data de atualização.
    /// </summary>
    /// <param name="updated"></param>
    /// <returns></returns>
    public SaleBuilder AddUpdated(DateTime? updated = null)
    {
        this.updated
           = updated
           ?? DateTime.Now;

        return this;
    }

    /// <summary>
    /// Adiciona o status.
    /// </summary>
    /// <param name="status"></param>
    /// <returns></returns>
    public SaleBuilder AddStatus(StatusVenda status)
    {
        this.status = status;

        return this;
    }

    /// <summary>
    /// Adiciona um cliente.
    /// </summary>
    /// <param name="client"></param>
    /// <returns></returns>
    public SaleBuilder AddClient(ClientEntity client)
    {
        this.client = client;

        return this;
    }

    /// <summary>
    /// Adiciona uma filial.
    /// </summary>
    /// <param name="client"></param>
    /// <returns></returns>
    public SaleBuilder AddBranch(BranchEntity branch)
    {
        this.branch = branch;

        return this;
    }

    /// <summary>
    /// Adiciona produtos.
    /// </summary>
    /// <param name="products"></param>
    /// <returns></returns>
    public SaleBuilder AddProducts(IEnumerable<ProductEntity> products)
    {
        this.products = products;

        return this;
    }

    /// <summary>
    /// Builder
    /// </summary>
    /// <returns></returns>
    public SaleEntity Builder() =>
        new(created, updated,
            status, client,
            branch, products.ToList()
        );
}
