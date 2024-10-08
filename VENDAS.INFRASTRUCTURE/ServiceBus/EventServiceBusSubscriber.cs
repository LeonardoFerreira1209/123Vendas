﻿using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Serilog;
using VENDAS.DOMAIN.Contracts.Providers.ServiceBus;
using VENDAS.DOMAIN.Contracts.Repositories;
using VENDAS.DOMAIN.Dtos.Configurations;
using VENDAS.DOMAIN.Dtos.ServiceBus;
using VENDAS.DOMAIN.Enums;
using VENDAS.INFRASTRUCTURE.Context;
using VENDAS.INFRASTRUCTURE.ServiceBus.Base;

namespace VENDAS.INFRASTRUCTURE.ServiceBus;

/// <summary>
/// Serviço de subscriber de eventos.
/// </summary>
/// <param name="appSettings"></param>
public class EventServiceBusSubscriber(
    IServiceProvider serviceProvider,
    IOptions<AppSettings> appSettings)
    : ServiceBusSubscriberBase(appSettings, QUEUE_OR_TOPIC_NAME), IServiceBusSubscriber
{
    /// <summary>
    /// Const de nome da queue ou topico.
    /// </summary>
    private const string QUEUE_OR_TOPIC_NAME = "events";

    /// <summary>
    /// String de conexão do service bus.
    /// </summary>
    private readonly string busConnection = Environment.GetEnvironmentVariable("SERVICEBUS_CONNECTION_STRING")
            ?? appSettings.Value.ServiceBus.ConnectionString;

    /// <summary>
    /// Processa as mensagens.
    /// </summary>
    /// <param name="messageEvent">Dados da mensagem do evento.</param>
    /// <returns>Task</returns>
    public override async Task ProcessMensageAsync(
        ProcessMessageEventArgs messageEvent)
    {
        var message = messageEvent.Message;

        try
        {
            EventMessage<object> eventMessage =
                JsonConvert.DeserializeObject<EventMessage<object>>(
                    message.Body.ToString());

            await ProccesByEventTypeAsync(
                eventMessage.EventType, eventMessage.Data)
                    .ContinueWith(async (task) =>
                    {

                        using var scope
                            = serviceProvider.CreateScope();

                        var eventRepository
                            = scope.ServiceProvider
                                .GetService<IEventRepository>();

                        await eventRepository.GetAsync(even
                            => even.Id == eventMessage.Id).ContinueWith(async (evenTask) =>
                            {
                                var eventEntity
                                    = evenTask.Result;

                                eventEntity.Processed
                                    = DateTime.Now;

                                await eventRepository
                                    .UpdateAsync(eventEntity);

                                var unitOfWork = scope.ServiceProvider
                                    .GetService<IUnitOfWork<SaleContext>>();

                                await unitOfWork.CommitAsync();

                            }).Unwrap();

                    }).Unwrap();

            Log.Information(
                $"[LOG INFORMATION] - {nameof(EventServiceBusSubscriber)} - METHOD {nameof(ProcessMensageAsync)} - Memsagem consumida com sucesso: {JsonConvert.SerializeObject(eventMessage.Data)}.\n");
        }
        catch (Exception exception)
        {
            Log.Error($"[LOG ERROR] - Exception: {exception.Message} - {JsonConvert.SerializeObject(exception)}\n");

            var cloneMessage = new ServiceBusMessage(messageEvent.Message)
            {
                ScheduledEnqueueTime
                    = DateTime.UtcNow.AddHours(1)
            };

            ServiceBusSender sender =
                _busClient.CreateSender(QUEUE_OR_TOPIC_NAME);

            await sender.SendMessageAsync(cloneMessage);
            await sender.CloseAsync();

            throw;
        }
    }

    /// <summary>
    /// Processa a mensagem com base no tipo de evento.
    /// </summary>
    /// <param name="eventType">Tipo de evento</param>
    /// <param name="data">Dados do evento</param>
    /// <returns>Task</returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task ProccesByEventTypeAsync(EventType eventType, object data)
    {
        switch (eventType)
        {
            case EventType.CompraCriada:
                Log.Information("Notificação de compra criada.\n");
                break;
            case EventType.CompraCancelada:
                Log.Information("Notificação de compra cancelada.\n");
                break;
            case EventType.CompraAlterada:
                Log.Information("Notificação de compra alterada.\n");
                break;
            default:
                throw new NotImplementedException();
        }
    }
}
