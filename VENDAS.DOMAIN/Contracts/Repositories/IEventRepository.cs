﻿using VENDAS.DOMAIN.Contracts.Repositories.Base;
using VENDAS.DOMAIN.Entities;

namespace VENDAS.DOMAIN.Contracts.Repositories;

/// <summary>
/// Repositorio de eventos.
/// </summary>
public interface IEventRepository
    : IGenerictEntityCoreRepository<EventEntity>
{ }
