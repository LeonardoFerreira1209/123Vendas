namespace VENDAS.DOMAIN.Entities;

/// <summary>
/// Entidade de filial.
/// </summary>
/// <typeparam name="Guid"></typeparam>
public class BranchEntity : IEntityPrimaryKey<Guid>
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
