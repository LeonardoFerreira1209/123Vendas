using VENDAS.DOMAIN.Enums;

namespace VENDAS.DOMAIN.Dtos.Response;

/// <summary>
/// Objeto de transporte de dados de response de vendas.
/// </summary>
public class SaleResponse
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
    public BranchResponse Branch { get; set; }

    /// <summary>
    /// Dados do cliente.
    /// </summary>
    public ClientResponse Client { get; set; }

    /// <summary>
    /// Lista de dados de Produto.
    /// </summary>
    public IEnumerable<ProductResponse> Products { get; set; }

    /// <summary>
    /// Valor total.
    /// </summary>
    public decimal TotalAmount { get; set; }
}
