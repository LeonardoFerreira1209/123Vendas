namespace VENDAS.DOMAIN.Dtos.Request;

/// <summary>
/// Objeto de transporte de dados de request de cliente.
/// </summary>
public class ClientRequest
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
