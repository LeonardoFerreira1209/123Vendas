namespace VENDAS.DOMAIN.Dtos.Request;

/// <summary>
/// Objeto de transporte de dados de request de venda.
/// </summary>
public class SaleRequest
{
    /// <summary>
    /// Dados da filial.
    /// </summary>
    public BranchRequest Branch { get; set; }

    /// <summary>
    /// Dados do cliente.
    /// </summary>
    public ClientRequest Client { get; set; }

    /// <summary>
    /// Lista de dados de Produto.
    /// </summary>
    public IEnumerable<ProductRequest> Products { get; set; }
}
