using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Serilog.Context;
using Swashbuckle.AspNetCore.Annotations;
using VENDAS.DOMAIN.Dtos.Base;
using VENDAS.DOMAIN.Dtos.Request;
using VENDAS.DOMAIN.Dtos.Response;

namespace VENDAS.API.Controllers;

/// <summary>
/// Controller que cuida de vendas.
/// </summary>
[ApiController]
[Route("api/sales")]
public class SaleController()
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
            return null;
        }
    }
}
