﻿using Microsoft.Extensions.DependencyInjection;
using VENDAS.APPLICATION.Configurations.Extensions.Initializers;

namespace VENDAS.APPLICATION.Configurations.Extensions.Initializers;

/// <summary>
/// Classe de configuração do Cookies da aplicação.
/// </summary>
public static class CookieExtensions
{
    /// <summary>
    /// Configura os cookies da applicação.
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection ConfigureApplicationCookie(this IServiceCollection services)
        => services.ConfigureApplicationCookie(options =>
        {
            options.Cookie.HttpOnly = true;

            options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

            options.SlidingExpiration = true;
        });
}
