using VENDAS.DOMAIN.Contracts.Repositories;
using VENDAS.DOMAIN.Entities;
using VENDAS.INFRASTRUCTURE.Context;
using VENDAS.INFRASTRUCTURE.Repositories.Base;

namespace VENDAS.INFRASTRUCTURE.Repositories;

/// <summary>
/// Repositorio de eventos.
/// </summary>
public sealed class EventRepository(
    SaleContext context)
        : GenericEntityCoreRepository<EventEntity>(context), IEventRepository
{ }
