using Microsoft.AspNetCore.Mvc;
using VENDAS.DOMAIN.Dtos.Request;
using VENDAS.DOMAIN.Dtos.Request.Base;

namespace VENDAS.DOMAIN.Contracts.Services;

/// <summary>
/// Interface de Sale service.
/// </summary>
public interface ISaleService
{
    /// <summary>
    /// Método de criação de venda.
    /// </summary>
    /// <param name="saleRequest"></param>
    /// <returns></returns>
    Task<ObjectResult> CreateAsync(SaleRequest saleRequest, 
        CancellationToken cancellationToken
    );

    /// <summary>
    /// Método de atualização de venda.
    /// </summary>
    /// <param name="saleUpdateRequest"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<ObjectResult> UpdateAsync(
        SaleUpdateRequest saleUpdateRequest, 
        CancellationToken cancellationToken
    );

    /// <summary>
    /// Método de cancelamento de venda.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<ObjectResult> CancelationAsync(
        Guid id, 
        CancellationToken cancellationToken
    );

    /// <summary>
    /// Método de retorno de venda por Id.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<ObjectResult> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken
    );

    /// <summary>
    /// Retorna todos as vendas paginada.
    /// </summary>
    /// <param name="filterRequest"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<ObjectResult> GetAsync(
       FilterRequest filterRequest,
       CancellationToken cancellationToken
    );
}


