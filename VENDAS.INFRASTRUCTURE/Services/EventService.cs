using Newtonsoft.Json;
using Serilog;
using VENDAS.DOMAIN.Contracts.Factories;
using VENDAS.DOMAIN.Contracts.Providers.ServiceBus;
using VENDAS.DOMAIN.Contracts.Repositories;
using VENDAS.DOMAIN.Contracts.Services;
using VENDAS.DOMAIN.Dtos.ServiceBus;
using VENDAS.DOMAIN.Entities;
using VENDAS.INFRASTRUCTURE.Context;

namespace VENDAS.INFRASTRUCTURE.Services;

/// <summary>
/// Serviço de eventos.
/// </summary>
/// <param name="eventFactory"></param>
/// <param name="eventServiceBusProvider"></param>
/// <param name="eventRepository"></param>
public class EventService(
    IEventFactory eventFactory,
    IEventServiceBusProvider eventServiceBusProvider,
    IUnitOfWork<SaleContext> unitOfWork,
    IEventRepository eventRepository) : IEventService
{
    /// <summary>
    /// Executa uma task.
    /// </summary>
    /// <returns></returns>
    public async Task ExecuteAsync()
        => await SendEventsToBusAsync();

    /// <summary>
    /// Envia um evento para o service bus.
    /// </summary>
    /// <returns></returns>
    public async Task SendEventsToBusAsync()
    {
        Log.Information(
            $"[LOG INFORMATION] - SET TITLE {nameof(EventService)} - METHOD {nameof(SendEventsToBusAsync)}\n");

        try
        {
            DateTime currentDate
                = DateTime.Now;

            ICollection<EventEntity> events
                = await eventRepository.GetAllAsync(
                    x => x.SchedulerTime <= currentDate && x.Sended == null);

            foreach (EventEntity even in events)
            {
                var message =
                       eventFactory.CreateEventMessage<MessageBase>(
                           even.Type, even.JsonBody, even.Id);

                await eventServiceBusProvider
                    .SendAsync(message).ContinueWith(async (Task) =>
                    {
                        Log.Information(
                             $"[LOG INFORMATION] - Evento enviado para o service bus: {JsonConvert.SerializeObject(message)}\n");

                        even.Sended = DateTime.Now;
                        await eventRepository.UpdateAsync(even);
                    });
            }

            await unitOfWork
                    .CommitAsync();
        }
        catch (Exception exception)
        {
            Log.Error($"[LOG ERROR] - Exception: {exception.Message} - {JsonConvert.SerializeObject(exception)}\n"); throw;
        }
    }
}
