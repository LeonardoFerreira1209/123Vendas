using Bogus;
using VENDAS.DOMAIN.Dtos.Request;

namespace _123Vendas.Test.Mocks.Sales;

public static class SalesMock
{
    public static SaleRequest GenerateFakeSaleRequestValid()
    {
        // Faker para ProductRequest
        var productFaker = new Faker<ProductRequest>()
            .RuleFor(p => p.Id, f => Guid.NewGuid())
            .RuleFor(p => p.Name, f => f.Commerce.ProductName())
            .RuleFor(p => p.Description, f => f.Commerce.ProductDescription())
            .RuleFor(p => p.UnitValue, f => f.Random.Decimal(10, 1000))
            .RuleFor(p => p.Quantity, f => f.Random.Int(1, 100))
            .RuleFor(p => p.Discount, f => f.Random.Decimal(0, 100));

        // Faker para ClientRequest
        var clientFaker = new Faker<ClientRequest>()
            .RuleFor(c => c.Id, f => Guid.NewGuid())
            .RuleFor(c => c.Name, f => f.Person.FullName)
            .RuleFor(c => c.Email, f => f.Internet.Email());

        // Faker para BranchRequest
        var branchFaker = new Faker<BranchRequest>()
            .RuleFor(b => b.Id, f => Guid.NewGuid())
            .RuleFor(b => b.Name, f => f.Company.CompanyName())
            .RuleFor(b => b.Description, f => f.Lorem.Sentence())
            .RuleFor(b => b.Country, f => f.Address.Country());

        // Faker para SaleRequest
        var saleRequestFaker = new Faker<SaleRequest>()
            .RuleFor(s => s.Branch, f => branchFaker.Generate())
            .RuleFor(s => s.Client, f => clientFaker.Generate())
            .RuleFor(s => s.Products, f => productFaker.Generate(3)); // Gera 3 produtos aleatórios

        return saleRequestFaker.Generate();
    }

    public static SaleRequest GenerateFakeSaleRequestInvalid()
    {
        // Faker para ProductRequest
        var productFaker = new Faker<ProductRequest>()
            .RuleFor(p => p.Id, f => Guid.NewGuid())
            .RuleFor(p => p.Name, f => f.Commerce.ProductName())
            .RuleFor(p => p.Description, f => f.Commerce.ProductDescription())
            .RuleFor(p => p.UnitValue, f => f.Random.Decimal(10, 1000))
            .RuleFor(p => p.Quantity, f => f.Random.Int(1, 100))
            .RuleFor(p => p.Discount, f => f.Random.Decimal(0, 100));

        // Faker para SaleRequest
        var saleRequestFaker = new Faker<SaleRequest>();

        return saleRequestFaker.Generate();
    }
}
