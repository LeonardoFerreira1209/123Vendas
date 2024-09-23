using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Serilog;
using System.Net;
using VENDAS.DOMAIN.Builders.Creates;
using VENDAS.DOMAIN.Contracts.Repositories;
using VENDAS.DOMAIN.Contracts.Services;
using VENDAS.DOMAIN.Dtos.Request;
using VENDAS.DOMAIN.Dtos.Request.Base;
using VENDAS.DOMAIN.Dtos.Response;
using VENDAS.DOMAIN.Dtos.Response.Base;
using VENDAS.DOMAIN.Entities;
using VENDAS.DOMAIN.Enums;
using VENDAS.DOMAIN.Exceptions.Base;
using VENDAS.DOMAIN.Helpers.Extensions;
using VENDAS.DOMAIN.Helpers.Extensions.Sales;
using VENDAS.DOMAIN.Validators;
using VENDAS.INFRASTRUCTURE.Context;

namespace VENDAS.APPLICATION.Services;

/// <summary>
/// Serviço de vendas.
/// </summary>
public class SaleService(
    ICachingService cachingService,
    IUnitOfWork<SaleContext> unitOfWork,
    ISaleRepository saleRepository,
    IEventRepository eventRepository) : ISaleService
{
    /// <summary>
    /// Método de criação de venda.
    /// </summary>
    /// <param name="saleRequest"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<ObjectResult> CreateAsync(
        SaleRequest saleRequest,
        CancellationToken cancellationToken)
    {
        Log.Information(
          $"[LOG INFORMATION] - SET TITLE {nameof(SaleService)} - METHOD {nameof(CreateAsync)}\n");

        try
        {
            await new SaleRequestValidator()
                .ValidateAsync(saleRequest, cancellationToken)
                    .ContinueWith(async (validationTask) =>
                    {
                        var validation = validationTask.Result;

                        if (validation.IsValid is false)
                            await validation.GetValidationErrors();

                    }).Unwrap();

            var transaction =
              await unitOfWork.BeginTransactAsync();

            try
            {
                SaleEntity sale = saleRequest.ToEntity();

                return await saleRepository.CreateAsync(sale)
                    .ContinueWith(async (task) =>
                    {
                        sale = task.Result;

                        await eventRepository.CreateAsync(
                            CreateEvent.SaleCreatedEvent(JsonConvert.SerializeObject(sale))
                        );

                        await unitOfWork.CommitAsync();
                        await transaction.CommitAsync();

                        return new ObjectResponse(
                            (int)HttpStatusCode.Created,
                            new ApiResponse<SaleResponse>(
                                true,
                                HttpStatusCode.Created,
                                sale.ToResponse(), [
                                    new DadosNotificacao("Venda criada com sucesso!")
                                ]
                            )
                        );

                    }).Unwrap();
            }
            catch (Exception)
            {
                transaction.Rollback();

                throw;
            }
        }
        catch (Exception exception)
        {
            Log.Error(
                $"[LOG ERROR] - Exception: {exception.Message} - {JsonConvert.SerializeObject(exception)}\n");

            throw;
        }
    }

    /// <summary>
    /// Método de atualização de venda.
    /// </summary>
    /// <param name="saleUpdateRequest"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<ObjectResult> UpdateAsync(
        SaleUpdateRequest saleUpdateRequest,
        CancellationToken cancellationToken)
    {
        Log.Information(
          $"[LOG INFORMATION] - SET TITLE {nameof(SaleService)} - METHOD {nameof(UpdateAsync)}\n");

        try
        {
            await new SaleUpdateRequestValidator()
                .ValidateAsync(saleUpdateRequest, cancellationToken)
                    .ContinueWith(async (validationTask) =>
                    {
                        var validation = validationTask.Result;

                        if (validation.IsValid is false)
                            await validation.GetValidationErrors();

                    }).Unwrap();

            var transaction =
              await unitOfWork.BeginTransactAsync();

            try
            {
                return await saleRepository.GetByIdAsync(saleUpdateRequest.Id)
                    .ContinueWith(async (saleTask) =>
                    {
                        var sale = saleTask.Result
                            ?? throw new CustomException(
                                HttpStatusCode.NotFound,
                                saleUpdateRequest, [
                                    new("Venda não encontrada.")
                                ]
                            );

                        return await saleRepository.UpdateAsync(
                                saleUpdateRequest.UpdateEntity(sale)
                            )
                            .ContinueWith(async (task) =>
                            {
                                await eventRepository.CreateAsync(
                                    CreateEvent.SaleUpdatedEvent(JsonConvert.SerializeObject(sale))
                                );

                                await unitOfWork.CommitAsync();
                                await transaction.CommitAsync();

                                return new ObjectResponse(
                                    (int)HttpStatusCode.OK,
                                    new ApiResponse<SaleResponse>(
                                        true,
                                        HttpStatusCode.OK,
                                        sale.ToResponse(), [
                                            new DadosNotificacao("Venda atualizada com sucesso!")
                                        ]
                                    )
                                );

                            }).Unwrap();

                    }).Unwrap();
            }
            catch (Exception)
            {
                transaction.Rollback();

                throw;
            }
        }
        catch (Exception exception)
        {
            Log.Error(
                $"[LOG ERROR] - Exception: {exception.Message} - {JsonConvert.SerializeObject(exception)}\n");

            throw;
        }
    }

    /// <summary>
    /// Método de cancelamento de venda.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<ObjectResult> CancelationAsync(
        Guid id,
        CancellationToken cancellationToken)
    {
        Log.Information(
          $"[LOG INFORMATION] - SET TITLE {nameof(SaleService)} - METHOD {nameof(CancelationAsync)}\n");

        try
        {
            var transaction =
              await unitOfWork.BeginTransactAsync();

            try
            {
                return await saleRepository.GetByIdAsync(id)
                    .ContinueWith(async (saleTask) =>
                    {
                        var sale = saleTask.Result
                            ?? throw new CustomException(
                                HttpStatusCode.NotFound,
                                null, [
                                    new("Venda não encontrada.")
                                ]
                            );

                        sale.Status
                            = StatusVenda.Cancelado;

                        return await saleRepository.UpdateAsync(
                                sale
                            )
                            .ContinueWith(async (task) =>
                            {
                                await eventRepository.CreateAsync(
                                    CreateEvent.SaleCanceledEvent(JsonConvert.SerializeObject(sale))
                                );

                                await unitOfWork.CommitAsync();
                                await transaction.CommitAsync();

                                return new ObjectResponse(
                                    (int)HttpStatusCode.OK,
                                    new ApiResponse<SaleResponse>(
                                        true,
                                        HttpStatusCode.OK,
                                        sale.ToResponse(), [
                                            new DadosNotificacao("Venda cancelada com sucesso!")
                                        ]
                                    )
                                );

                            }).Unwrap();

                    }).Unwrap();
            }
            catch (Exception)
            {
                transaction.Rollback();

                throw;
            }
        }
        catch (Exception exception)
        {
            Log.Error(
                $"[LOG ERROR] - Exception: {exception.Message} - {JsonConvert.SerializeObject(exception)}\n");

            throw;
        }
    }

    /// <summary>
    /// Método de retorno de venda por Id.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<ObjectResult> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken)
    {
        Log.Information(
          $"[LOG INFORMATION] - SET TITLE {nameof(SaleService)} - METHOD {nameof(GetByIdAsync)}\n");

        try
        {
            string cacheKey =
              $"get-sale-{id}";

            ObjectResponse saleCache =
                await cachingService
                    .GetAsync<ObjectResponse>(cacheKey);

            if (saleCache is not null)
                return saleCache;

            return await saleRepository.GetByIdAsync(id)
                .ContinueWith(async (saleTask) =>
                {
                    var sale = saleTask.Result
                        ?? throw new CustomException(
                            HttpStatusCode.NotFound,
                            null, [
                                new("Venda não encontrada.")
                            ]
                        );

                    ObjectResponse response =  new(
                        (int)HttpStatusCode.OK,
                        new ApiResponse<SaleResponse>(
                            true,
                            HttpStatusCode.OK,
                            sale.ToResponse(), [
                                new DadosNotificacao("Venda retornada com sucesso!")
                            ]
                        )
                    );

                    await cachingService
                        .SetAsync(cacheKey, response);

                    return response;

                }).Unwrap();
        }
        catch (Exception exception)
        {
            Log.Error(
                $"[LOG ERROR] - Exception: {exception.Message} - {JsonConvert.SerializeObject(exception)}\n");

            throw;
        }
    }

    /// <summary>
    /// Método de retorno de vendas.
    /// </summary>
    /// <param name="filterRequest"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<ObjectResult> GetAsync(
        FilterRequest filterRequest,
        CancellationToken cancellationToken)
    {
        Log.Information(
          $"[LOG INFORMATION] - SET TITLE {nameof(SaleService)} - METHOD {nameof(GetByIdAsync)}\n");

        try
        {
            string cacheKey =
               $"getall-sales-{filterRequest.PageNumber}-{filterRequest.PageSize}";

            ObjectResponse saleCache =
                await cachingService
                    .GetAsync<ObjectResponse>(cacheKey);

            if (saleCache is not null)
                return saleCache;

            return await saleRepository.GetAllAsyncPaginated(
                filterRequest.PageNumber,
                filterRequest.PageSize
            )
            .ContinueWith(async (taskResult) =>
            {
                var pagination
                    = taskResult.Result;

                ObjectResponse response = new(
                    (int)HttpStatusCode.OK,
                    new PaginationApiResponse<SaleResponse>(
                       true,
                       HttpStatusCode.OK,
                       pagination.ConvertPaginationData
                            (pagination.Items.Select(
                                sale => sale.ToResponse()).ToList()), [
                                    new DadosNotificacao("Tenants reuperados com sucesso!")
                                ]
                            )
                    );

                await cachingService
                    .SetAsync(cacheKey, response);

                return response;

            }).Unwrap();
        }
        catch (Exception exception)
        {
            Log.Error(
                $"[LOG ERROR] - Exception: {exception.Message} - {JsonConvert.SerializeObject(exception)}\n");

            throw;
        }
    }
}
