using VENDAS.DOMAIN.Contracts.Repositories.Base;
using VENDAS.DOMAIN.Entities;

namespace VENDAS.DOMAIN.Contracts.Repositories;

/// <summary>
/// Repositorio de sales.
/// </summary>
public interface ISaleRepository
    : IGenerictEntityCoreRepository<SaleEntity>
{ }
