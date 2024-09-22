namespace VENDAS.DOMAIN.Dtos.Response;

/// <summary>
/// Objeto de transporte de dados de response de filial.
/// </summary>
public class BranchResponse
{
    /// <summary>
    /// Identificador.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Nome.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Descrição.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Pais.
    /// </summary>
    public string Country { get; set; }
}
