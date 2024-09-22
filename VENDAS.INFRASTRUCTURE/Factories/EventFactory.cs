using Newtonsoft.Json;
using VENDAS.DOMAIN.Contracts.Factories;
using VENDAS.DOMAIN.Dtos.ServiceBus;
using VENDAS.DOMAIN.Enums;

namespace VENDAS.INFRASTRUCTURE.Factories;

/// <summary>
/// Factory de mensagens de eventos.
/// </summary>
public class EventFactory : IEventFactory
{
    /// <summary>
    /// Cria uma mensagem de evento.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="eventType"></param>
    /// <param name="jsonBody"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public EventMessage<T> CreateEventMessage<T>(
        EventType eventType, string jsonBody, Guid eventId) where T : class
    {
        var deserializeObject
            = JsonConvert.DeserializeObject<T>(jsonBody);

        return new EventMessage<T>(
                    deserializeObject, eventType, eventId);
    }
}
