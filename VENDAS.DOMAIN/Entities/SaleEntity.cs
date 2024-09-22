using VENDAS.DOMAIN.Enums;

namespace VENDAS.DOMAIN.Entities;

/// <summary>
/// Entidade de venda.
/// </summary>
/// <remarks>
/// ctor
/// </remarks>
/// <param name="created"></param>
/// <param name="status"></param>
/// <param name="updated"></param>
/// <param name="client"></param>
/// <param name="branch"></param>
/// <param name="products"></param>
public class SaleEntity : IEntityBase
{
    /// <summary>
    /// ctor
    /// </summary>
    public SaleEntity()
    {
        
    }

    /// <summary>
    /// ctor
    /// </summary>
    /// <param name="created"></param>
    /// <param name="updated"></param>
    /// <param name="status"></param>
    /// <param name="client"></param>
    /// <param name="branch"></param>
    /// <param name="products"></param>
    public SaleEntity(DateTime created, DateTime? updated,
        StatusVenda status, ClientEntity client,
        BranchEntity branch, ICollection<ProductEntity> products)
    {
        Created = created;
        Updated = updated;
        Status = status;
        Client = client;
        Branch = branch;
        Products = products;
    }

    /// <summary>
    /// Identificador.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Data de criação.
    /// </summary>
    public DateTime Created { get; set; }

    /// <summary>
    /// Data de atualização.
    /// </summary>
    public DateTime? Updated { get; set; }

    /// <summary>
    /// Status do cadastro.
    /// </summary>
    public StatusVenda Status { get; set; }

    /// <summary>
    /// Dados da filial.
    /// </summary>
    public virtual BranchEntity Branch { get; set; }

    /// <summary>
    /// Dados do cliente.
    /// </summary>
    public virtual ClientEntity Client { get; set; }

    /// <summary>
    /// Lista de dados de Produto.
    /// </summary>
    public virtual ICollection<ProductEntity> Products { get; set; }

    /// <summary>
    /// Valor total.
    /// </summary>
    public decimal TotalAmount {

        get => Products?.Sum(p => p.TotalAmount) ?? 0;

        private set { }
    }
}
