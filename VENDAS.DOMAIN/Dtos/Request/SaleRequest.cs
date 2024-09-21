using System.ComponentModel.DataAnnotations;

namespace VENDAS.DOMAIN.Dtos.Request;

/// <summary>
/// Objeto de transporte de dados de request de venda.
/// </summary>
public class SaleRequest
{
    /// <summary>
    /// Dados da filial.
    /// </summary>
    [Required()]
    public BranchResponse Branch { get; set; }

    /// <summary>
    /// Dados do cliente.
    /// </summary>
    [Required()]
    public ClientRequest Client { get; set; }

    /// <summary>
    /// Lista de dados de Produto.
    /// </summary>
    [Required()]
    public IEnumerable<ProductRequest> Products { get; set; }
}
