namespace VENDAS.DOMAIN.Entities;

/// <summary>
/// Entidade de client.
/// </summary>
public class ClientEntity : IEntityPrimaryKey<Guid>
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
