using Microsoft.AspNetCore.Builder;
using VENDAS.INFRASTRUCTURE.Middlewares;

namespace VENDAS.APPLICATION.Configurations.Extensions.Initializers;

/// <summary>
/// Configuração de uso de middlewares no sistema.
/// </summary>
public static class MiddlewareExtensions
{
    /// <summary>
    /// Configuração de pipeline de middlewares no sistema.
    /// </summary>
    /// <param name="application"></param>
    /// <returns></returns>
    public static IApplicationBuilder UseMiddlewareConfiguration(
        this IApplicationBuilder application)
    {
        application.UseMiddleware<ErrorHandlerMiddleware>();

        return application;
    }
}
