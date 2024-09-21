using VENDAS.DOMAIN.Contracts.Repositories;
using VENDAS.DOMAIN.Entities;
using VENDAS.INFRASTRUCTURE.Context;
using VENDAS.INFRASTRUCTURE.Repositories.Base;

namespace VENDAS.INFRASTRUCTURE.Repositories;

/// <summary>
/// Repositorio de sale.
/// </summary>
public sealed class SaleRepository(
    SaleContext context)
        : GenericEntityCoreRepository<SaleEntity>(context), ISaleRepository
{ }
