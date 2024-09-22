using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VENDAS.APPLICATION.Services;
using VENDAS.DOMAIN.Contracts.Factories;
using VENDAS.DOMAIN.Contracts.Providers.ServiceBus;
using VENDAS.DOMAIN.Contracts.Repositories;
using VENDAS.DOMAIN.Contracts.Repositories.Base;
using VENDAS.DOMAIN.Contracts.Services;
using VENDAS.INFRASTRUCTURE.Factories;
using VENDAS.INFRASTRUCTURE.Repositories;
using VENDAS.INFRASTRUCTURE.Repositories.Base;
using VENDAS.INFRASTRUCTURE.ServiceBus;
using VENDAS.INFRASTRUCTURE.Services;

namespace VENDAS.APPLICATION.Configurations.Extensions.Initializers;

/// <summary>
/// Classe de configuração do depêndencias da aplicação.
/// </summary>
public static class DependenciesExtensions
{
    /// <summary>
    /// Configuração das dependencias (Serrvices, Repository, Facades, etc...).
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection ConfigureDependencies(
        this IServiceCollection services, IConfiguration configurations)
    {
        services
        // Others    
            .AddSingleton(serviceProvider => configurations)
        // Services
            .AddTransient<IContextService, ContextService>()
            .AddTransient<IAuthenticationService, AuthenticationService>()
            .AddTransient<ISaleService, SaleService>()
            .AddTransient<IEventService, EventService>()
        // Repository
            .AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>))
            .AddScoped(typeof(IGenerictEntityCoreRepository<>), typeof(GenericEntityCoreRepository<>))
            .AddScoped<ISaleRepository, SaleRepository>()
            .AddScoped<IEventRepository, EventRepository>()
        // Infra
            .AddSingleton<ICachingService, CachingService>()
            .AddTransient<IEventFactory, EventFactory>()
            .AddTransient<IEventServiceBusProvider, EventServiceBusProvider>()
            .AddSingleton<EventServiceBusSubscriber>();

        return services;
    }
}
