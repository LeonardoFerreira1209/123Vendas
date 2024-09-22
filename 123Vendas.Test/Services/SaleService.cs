using _123Vendas.Test.Mocks.Sales;
using Microsoft.EntityFrameworkCore.Storage;
using Moq;
using System.Net;
using VENDAS.APPLICATION.Services;
using VENDAS.DOMAIN.Contracts.Repositories;
using VENDAS.DOMAIN.Contracts.Services;
using VENDAS.DOMAIN.Dtos.Response;
using VENDAS.DOMAIN.Dtos.Response.Base;
using VENDAS.DOMAIN.Entities;
using VENDAS.DOMAIN.Exceptions.Base;
using VENDAS.DOMAIN.Helpers.Extensions.Sales;
using VENDAS.INFRASTRUCTURE.Context;

namespace _123Vendas.Test.Services;

/// <summary>
/// Classe de teste de sales service.
/// </summary>
public class SaleServiceTests
{
    private readonly Mock<ICachingService> _cachingServiceMock;
    private readonly Mock<IUnitOfWork<SaleContext>> _unitOfWorkMock;
    private readonly Mock<ISaleRepository> _saleRepositoryMock;
    private readonly Mock<IEventRepository> _eventRepositoryMock;
    private readonly SaleService _saleService;

    /// <summary>
    /// ctor
    /// </summary>
    public SaleServiceTests()
    {
        _cachingServiceMock = new Mock<ICachingService>();
        _unitOfWorkMock = new Mock<IUnitOfWork<SaleContext>>();
        _saleRepositoryMock = new Mock<ISaleRepository>();
        _eventRepositoryMock = new Mock<IEventRepository>();

        _saleService = new SaleService(
            _cachingServiceMock.Object,
            _unitOfWorkMock.Object,
            _saleRepositoryMock.Object,
            _eventRepositoryMock.Object
        );
    }

    /// <summary>
    /// Sucesso na criação.
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task CreateAsync_ShouldReturnCreatedResponse_WhenSaleIsCreated()
    {
        // Arrange
        var saleRequest 
            = SalesMock
                .GenerateFakeSaleRequestValid();

        var saleEntity = saleRequest.ToEntity();

        _saleRepositoryMock
            .Setup(repo => repo.CreateAsync(It.IsAny<SaleEntity>()))
            .ReturnsAsync(saleEntity);

        _unitOfWorkMock
            .Setup(uow => uow.BeginTransactAsync())
            .ReturnsAsync(Mock.Of<IDbContextTransaction>());

        // Act
        var result = await _saleService.CreateAsync(saleRequest, CancellationToken.None);

        // Assert
        var objectResult = Assert.IsType<ObjectResponse>(result);
        Assert.Equal((int)HttpStatusCode.Created, objectResult.StatusCode);
        var apiResponse = Assert.IsType<ApiResponse<SaleResponse>>(objectResult.Value);
        Assert.True(apiResponse.Sucesso);
    }

    /// <summary>
    /// Falha na criação.
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task CreateAsync_ShouldThrowValidationException_WhenValidationFails()
    {
        // Arrange
        var saleRequest
            = SalesMock
                .GenerateFakeSaleRequestInvalid();

        // Act & Assert
        await Assert.ThrowsAsync<CustomException>(() 
            => _saleService.CreateAsync(saleRequest, CancellationToken.None));
    }
}
