namespace VENDAS.DOMAIN.Dtos.Request;

/// <summary>
/// Objeto de transporte de dados de response de cliente.
/// </summary>
public class ClientResponse
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
    /// Informação do email.
    /// </summary>
    public string Email { get; set; }
}
