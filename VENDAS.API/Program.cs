using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Text.Json.Serialization;
using VENDAS.APPLICATION.Configurations.Extensions.Initializers;
using VENDAS.DOMAIN.Dtos.Configurations;

try
{
    var builder = WebApplication.CreateBuilder(args);

    var configurations = builder.Configuration;

    /// <sumary>
    /// Pega o appsettings baseado no ambiente em execução.
    /// </sumary>
    configurations
         .SetBasePath(builder.Environment.ContentRootPath)
            .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
                    .AddEnvironmentVariables();

    configurations
        .SetBasePath(builder.Environment.ContentRootPath)
           .AddJsonFile("identitysettings.json", true, true)
                   .AddEnvironmentVariables();

    /// <sumary>
    /// Configura as configurações de inicialização da aplicação.
    /// </sumary>
    builder.Services
        .ConfigureSerilog(configurations)
        .AddHttpContextAccessor()
        .Configure<AppSettings>(configurations)
        .AddSingleton<AppSettings>()
        .AddEndpointsApiExplorer()
        .AddOptions()
        .ConfigureLanguage()
        .ConfigureDependencies(configurations)
        .ConfigureDataBase(configurations)
        .ConfigureAuthentication(configurations)
        .ConfigureApplicationCookie()
        .ConfigureCors()
        .AddMemoryCache()
        .AddControllers(options =>
        {
            options.EnableEndpointRouting = false;
            options.Filters.Add(new ProducesAttribute("application/json"));

        }).AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        });

    builder.Services
           .ConfigureSwagger(configurations);

    var applicationbuilder = builder.Build();

    applicationbuilder
        .UseMiddlewareConfiguration()
        .UseDefaultFiles()
        .UseStaticFiles()
        .UseCookiePolicy()
        .UseCors()
        .UseResponseCaching()
        .UseAuthentication()
        .UseSwaggerConfigurations(configurations);

    applicationbuilder.UseHsts();
    applicationbuilder.MapControllers();

    //applicationbuilder
    //    .ConfigureServiceBusSubscriber();

    applicationbuilder
       .Lifetime.ApplicationStarted
           .Register(() => Log.Debug(
                   $"[LOG DEBUG] - Aplicação inicializada com sucesso: [VENDAS.API]\n"));

    applicationbuilder.Run();
}
catch (Exception exception)
{
    Log.Error($"[LOG ERROR] - Ocorreu um erro ao inicializar a aplicacao [VENDAS.API] - {exception.Message}\n"); throw;
}