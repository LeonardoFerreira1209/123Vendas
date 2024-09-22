namespace VENDAS.DOMAIN.Contracts.Providers.ServiceBus;

/// <summary>
/// Interface de subscriber de eventos.
/// </summary>
public interface IEventServiceBusSubscriber
{
    /// <summary>
    /// Registrar handler de recebimento de eventos.
    /// </summary>
    public void RegisterReceiveMessageHandler();
}
