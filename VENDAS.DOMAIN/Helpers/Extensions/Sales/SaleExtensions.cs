using VENDAS.DOMAIN.Builders.Creates;
using VENDAS.DOMAIN.Dtos.Request;
using VENDAS.DOMAIN.Dtos.Response;
using VENDAS.DOMAIN.Entities;

namespace VENDAS.DOMAIN.Helpers.Extensions.Sales;

/// <summary>
/// Classe de extensão de Venda.
/// </summary>
public static class SaleExtensions
{
    /// <summary>
    /// Converte request em entidade
    /// </summary>
    /// <param name="saleRequest"></param>
    /// <returns></returns>
    public static SaleEntity ToEntity(
        this SaleRequest saleRequest)
            => CreateDefaultSale.Create(
                saleRequest.Client.ToEntity(),
                saleRequest.Branch.ToEntity(),
                saleRequest.Products.Select(p => p.ToEntity())
            );

    /// <summary>
    /// Converte request em entidade
    /// </summary>
    /// <param name="saleRequest"></param>
    /// <returns></returns>
    public static SaleEntity UpdateEntity(
        this SaleUpdateRequest saleUpdateRequest,
        SaleEntity saleEntity)
    {
        saleEntity.Updated = DateTime.Now;

        saleEntity.Branch = saleUpdateRequest?
            .Branch?
            .ToEntity() ?? saleEntity.Branch;
        
        saleEntity.Client = saleUpdateRequest?
            .Client?
            .ToEntity() ?? saleEntity.Client;   

        saleEntity.Products = saleUpdateRequest?
            .Products?.Select(x => x.ToEntity()).ToList();

        return saleEntity;
    }

    /// <summary>
    /// Converte request em entidade.
    /// </summary>
    /// <param name="branchRequest"></param>
    /// <returns></returns>
    public static BranchEntity ToEntity(
        this BranchRequest branchRequest) => new()
        {
            Id = branchRequest.Id,
            Country = branchRequest.Country,
            Description = branchRequest.Description,
            Name = branchRequest.Name
        };

    /// <summary>
    /// Converte request em entidade.
    /// </summary>
    /// <param name="clientRequest"></param>
    /// <returns></returns>
    public static ClientEntity ToEntity(
        this ClientRequest clientRequest) => new()
        {
            Id = clientRequest.Id,
            Name = clientRequest.Name,
            Email = clientRequest.Email,
        };

    /// <summary>
    /// Converte request em entidade.
    /// </summary>
    /// <param name="productRequest"></param>
    /// <returns></returns>
    public static ProductEntity ToEntity(
        this ProductRequest productRequest) => new()
        {
            Id = productRequest.Id,
            Name = productRequest.Name,
            Description = productRequest.Description,
            Discount = productRequest.Discount,
            Quantity = productRequest.Quantity,
            UnitValue = productRequest.UnitValue,
        };

    /// <summary>
    /// Converte entidade em response.
    /// </summary>
    /// <param name="sale"></param>
    /// <returns></returns>
    public static SaleResponse ToResponse(
        this SaleEntity sale) => new()
        {
            Id = sale.Id,
            Branch = sale.Branch.ToResponse(),
            Client = sale.Client.ToResponse(),
            Products = sale.Products.Select(x => x.ToResponse()),
            Created = sale.Created,
            Updated = sale.Updated,
            Status = sale.Status,
            TotalAmount = sale.TotalAmount,
        };

    /// <summary>
    /// Converte entidade em response.
    /// </summary>
    /// <param name="branch"></param>
    /// <returns></returns>
    public static BranchResponse ToResponse(
        this BranchEntity branch) => new()
        {
            Id = branch.Id,
            Country = branch.Country,
            Description = branch.Description,
            Name = branch.Name
        };

    /// <summary>
    /// Converte entidade em response.
    /// </summary>
    /// <param name="clientResponse"></param>
    /// <returns></returns>
    public static ClientResponse ToResponse(
        this ClientEntity client) => new()
        {
            Id = client.Id,
            Name = client.Name,
            Email = client.Email
        };

    /// <summary>
    /// Converte entidade em resquest.
    /// </summary>
    /// <param name="product"></param>
    /// <returns></returns>
    public static ProductResponse ToResponse(
        this ProductEntity product) => new()
        {
            Id = product.Id,
            Description = product.Description,
            Discount = product.Discount,
            Quantity = product.Quantity,
            Name = product.Name,
            TotalAmount = product.TotalAmount,
            UnitValue = product.UnitValue
        };
}
