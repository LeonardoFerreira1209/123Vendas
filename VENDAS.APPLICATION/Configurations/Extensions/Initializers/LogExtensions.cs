using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;

namespace VENDAS.APPLICATION.Configurations.Extensions.Initializers;

/// <summary>
/// Log extensions.
/// </summary>
public static class LogExtensions
{
    /// <summary>
    /// Configuração de Logs do sistema.
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection ConfigureSerilog(this IServiceCollection services, IConfiguration configurations)
    {
        string connectionString = Environment
            .GetEnvironmentVariable("MYSQL_DATABASE") ?? configurations.GetConnectionString("DataBase");

        Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .MinimumLevel.Override("System", LogEventLevel.Error)
                .Enrich.FromLogContext()
                .Enrich.WithEnvironmentUserName()
                .Enrich.WithMachineName()
                .Enrich.WithProcessId()
                .Enrich.WithProcessName()
                .Enrich.WithThreadId()
                .Enrich.WithThreadName()
                .WriteTo.Console()
                .WriteTo.MySQL(connectionString)
                .CreateLogger();

        return services;
    }
}
