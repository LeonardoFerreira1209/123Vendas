using Microsoft.Extensions.Options;
using VENDAS.DOMAIN.Contracts.Providers.ServiceBus;
using VENDAS.DOMAIN.Dtos.Configurations;
using VENDAS.INFRASTRUCTURE.ServiceBus.Base;

namespace VENDAS.INFRASTRUCTURE.ServiceBus;

/// <summary>
/// Classe de provider barramento de mensagem de eventos.
/// </summary>
public class EventServiceBusProvider(IOptions<AppSettings> appsettings)
    : ServiceBusProviderBase(
        Environment.GetEnvironmentVariable("SERVICEBUS_CONNECTION_STRING")
            ?? appsettings.Value.ServiceBus.ConnectionString, "events"), IEventServiceBusProvider
{

}
