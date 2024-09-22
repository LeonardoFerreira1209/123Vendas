using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Serilog.Context;
using Swashbuckle.AspNetCore.Annotations;
using VENDAS.DOMAIN.Contracts.Services;
using VENDAS.DOMAIN.Dtos.Request;
using VENDAS.DOMAIN.Dtos.Request.Base;
using VENDAS.DOMAIN.Dtos.Response;
using VENDAS.DOMAIN.Dtos.Response.Base;

namespace VENDAS.API.Controllers;

/// <summary>
/// Controller que cuida de vendas.
/// </summary>
[ApiController]
[Route("api/sales")]
public class SaleController(ISaleService saleService)
{
    /// <summary>
    /// Endpoint responsável pelo registro de uma venda no sistema.
    /// </summary>
    /// <param name="saleRequest"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    [SwaggerOperation(Summary = "Realizar venda", Description = "Método responsável realizar uma venda!")]
    [ProducesResponseType(typeof(ApiResponse<SaleResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse<SaleResponse>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse<SaleResponse>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> RegisterAsync(
        [FromBody] SaleRequest saleRequest,
        CancellationToken cancellationToken)
    {
        using (LogContext.PushProperty("Controller", nameof(SaleController)))
        using (LogContext.PushProperty("Payload", JsonConvert.SerializeObject(saleRequest)))
        using (LogContext.PushProperty("Metodo", nameof(RegisterAsync)))
        {
           return await saleService
                .CreateAsync(
                    saleRequest, 
                    cancellationToken
                );
        }
    }

    /// <summary>
    /// Endpoint responsável pela atualização de uma venda no sistema.
    /// </summary>
    /// <param name="saleUpdateRequest"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPut]
    [SwaggerOperation(Summary = "Atualizar venda", Description = "Método responsável atualizar uma venda!")]
    [ProducesResponseType(typeof(ApiResponse<SaleResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse<SaleResponse>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse<SaleResponse>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateAsync(
        [FromBody] SaleUpdateRequest saleUpdateRequest,
        CancellationToken cancellationToken)
    {
        using (LogContext.PushProperty("Controller", nameof(SaleController)))
        using (LogContext.PushProperty("Payload", JsonConvert.SerializeObject(saleUpdateRequest)))
        using (LogContext.PushProperty("Metodo", nameof(UpdateAsync)))
        {
            return await saleService
                 .UpdateAsync(
                     saleUpdateRequest,
                     cancellationToken
                 );
        }
    }

    /// <summary>
    ///  Endpoint responsável pelo cancelamento da venda no sistema.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPatch("{id}/cancelation")]
    [SwaggerOperation(Summary = "Cancelar venda", Description = "Método responsável cancelar uma venda!")]
    [ProducesResponseType(typeof(ApiResponse<SaleResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse<SaleResponse>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse<SaleResponse>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CancelationAsync(
        Guid id,
        CancellationToken cancellationToken)
    {
        using (LogContext.PushProperty("Controller", nameof(SaleController)))
        using (LogContext.PushProperty("Metodo", nameof(CancelationAsync)))
        {
            return await saleService
                 .CancelationAsync(
                    id,
                    cancellationToken
                 );
        }
    }


    /// <summary>
    ///  Endpoint responsável pelo retorno de venda por Id.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Retorna venda", Description = "Método responsável por Retorna uma venda!")]
    [ProducesResponseType(typeof(ApiResponse<SaleResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse<SaleResponse>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse<SaleResponse>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken)
    {
        using (LogContext.PushProperty("Controller", nameof(SaleController)))
        using (LogContext.PushProperty("Metodo", nameof(GetByIdAsync)))
        {
            return await saleService
                 .CancelationAsync(
                    id,
                    cancellationToken
                 );
        }
    }

    /// <summary>
    ///  Endpoint responsável pelo retorno de venda por Id.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    [SwaggerOperation(Summary = "Retorna venda", Description = "Método responsável por Retorna uma venda!")]
    [ProducesResponseType(typeof(ApiResponse<SaleResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse<SaleResponse>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse<SaleResponse>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAsync(
        [FromQuery] FilterRequest filterRequest,
        CancellationToken cancellationToken)
    {
        using (LogContext.PushProperty("Controller", nameof(SaleController)))
        using (LogContext.PushProperty("Payload", JsonConvert.SerializeObject(filterRequest)))
        using (LogContext.PushProperty("Metodo", nameof(GetByIdAsync)))
        {
            return await saleService
                 .GetAsync(
                    filterRequest,
                    cancellationToken
                 );
        }
    }
}
