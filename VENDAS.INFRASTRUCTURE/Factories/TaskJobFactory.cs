﻿using Microsoft.Extensions.DependencyInjection;
using VENDAS.DOMAIN.Contracts.Factories;
using VENDAS.DOMAIN.Contracts.Services;

namespace VENDAS.INFRASTRUCTURE.Factories;

/// <summary>
/// Factory de Task de jobs.
/// </summary>
/// <param name="serviceProvider"></param>
public class TaskJobFactory(
    IServiceProvider serviceProvider) : ITaskJobFactory
{
    /// <summary>
    /// Recupera uma instancia do IExecuteJobTask baseada no nome.
    /// </summary>
    /// <param name="jobName"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public IExecuteJobTask GetJobTask(string jobName) => jobName switch
    {
        "SendEventsToBus"
            => serviceProvider.GetService<IEventService>(),
        _ =>
            throw new ArgumentException("Job não existe", nameof(jobName))
    };
}
