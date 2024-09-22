using VENDAS.DOMAIN.Entities;
using VENDAS.DOMAIN.Enums;

namespace VENDAS.DOMAIN.Builders.Creates;

/// <summary>
/// Cria um evento.
/// </summary>
public sealed class CreateEvent
{
    /// <summary>
    ///  Cria uma instância de evento de venda criada.
    /// </summary>
    /// <param name="jsonBody"></param>
    /// <returns></returns>
    public static EventEntity SaleCreatedEvent(string jsonBody)
        => new EventBuilder()
            .AddCreated(DateTime.Now)
            .AddJsonBody(jsonBody)
            .AddType(EventType.CompraCriada)
            .Builder();

    /// <summary>
    ///  Cria uma instância de evento de venda atualizada.
    /// </summary>
    /// <param name="jsonBody"></param>
    /// <returns></returns>
    public static EventEntity SaleUpdatedEvent(string jsonBody)
        => new EventBuilder()
            .AddCreated(DateTime.Now)
            .AddJsonBody(jsonBody)
            .AddType(EventType.CompraAlterada)
            .Builder();

    /// <summary>
    ///  Cria uma instância de evento de venda cancelada.
    /// </summary>
    /// <param name="jsonBody"></param>
    /// <returns></returns>
    public static EventEntity SaleCanceledEvent(string jsonBody)
        => new EventBuilder()
            .AddCreated(DateTime.Now)
            .AddJsonBody(jsonBody)
            .AddType(EventType.CompraCancelada)
            .Builder();
}
