using System.Text.Json.Serialization;

namespace VENDAS.DOMAIN.Dtos.ServiceBus;

/// <summary>
/// Classe de mensagem base.
/// </summary>
/// <param name="eventType"></param>
public class MessageBase(
   Guid? eventId = null)
{
    /// <summary>
    /// Id do evento.
    /// </summary>
    public Guid? Id { get; set; } = eventId ?? Guid.NewGuid();

    /// <summary>
    /// Cabeçalhos.
    /// </summary>
    [JsonIgnore]
    public Dictionary<string, object> Headers { get; set; }
}
