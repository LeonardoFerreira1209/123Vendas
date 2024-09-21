using VENDAS.DOMAIN.Enums;

namespace VENDAS.DOMAIN.Entities;

/// <summary>
/// Entidade de venda.
/// </summary>
public class SaleEntity : IEntityBase
{
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
    public DateTime? Updated { get; set; } = null;

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
    public virtual IEnumerable<ProductEntity> Products { get; set; } = [];

    /// <summary>
    /// Valor total.
    /// </summary>
    public decimal TotalAmount {

        get => Products?.Sum(p => p.TotalAmount) ?? 0;

        private set { }
    }
}
