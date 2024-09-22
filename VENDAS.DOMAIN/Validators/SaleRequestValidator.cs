using FluentValidation;
using VENDAS.DOMAIN.Dtos.Request;
using VENDAS.DOMAIN.Enums;
using VENDAS.DOMAIN.Helpers.Extensions;

namespace VENDAS.DOMAIN.Validators;

/// <summary>
/// Classe de validação de vendas.
/// </summary>
public class SaleRequestValidator : AbstractValidator<SaleRequest>
{
    public SaleRequestValidator()
    {
        // Validação do Cliente
        RuleFor(s => s.Client)
            .NotNull()
            .WithErrorCode(ErrorCode.ErroInesperado.ToCode())
            .WithMessage("Preencha os dados do Cliente.");

        RuleFor(s => s.Client.Id)
            .NotEmpty()
            .When(s => s.Client != null)
            .WithErrorCode(ErrorCode.ErroInesperado.ToCode())
            .WithMessage("Preencha o Id do Cliente.");

        RuleFor(s => s.Client.Name)
            .NotEmpty()
            .When(s => s.Client != null)
            .WithErrorCode(ErrorCode.ErroInesperado.ToCode())
            .WithMessage("Preencha o nome do Cliente.");

        RuleFor(s => s.Client.Email)
            .NotEmpty()
            .When(s => s.Client != null)
            .WithErrorCode(ErrorCode.ErroInesperado.ToCode())
            .WithMessage("Preencha o email do Cliente.");

        // Validação da Filial
        RuleFor(s => s.Branch)
            .NotNull()
            .WithErrorCode(ErrorCode.ErroInesperado.ToCode())
            .WithMessage("Preencha os dados da Filial.");

        RuleFor(s => s.Branch.Id)
            .NotEmpty()
            .When(s => s.Branch != null)
            .WithErrorCode(ErrorCode.ErroInesperado.ToCode())
            .WithMessage("Preencha o Id da Filial.");

        RuleFor(s => s.Branch.Name)
            .NotEmpty()
            .When(s => s.Branch != null)
            .WithErrorCode(ErrorCode.ErroInesperado.ToCode())
            .WithMessage("Preencha o nome da Filial.");

        RuleFor(s => s.Branch.Description)
            .NotEmpty()
            .When(s => s.Branch != null)
            .WithErrorCode(ErrorCode.ErroInesperado.ToCode())
            .WithMessage("Preencha a descrição da Filial.");

        // Validação de Produtos
        RuleFor(s => s.Products)
            .NotNull()
            .NotEmpty()
            .WithErrorCode(ErrorCode.ErroInesperado.ToCode())
            .WithMessage("Preencha os dados de Produtos.");

        RuleForEach(s => s.Products).SetValidator(new ProductRequestValidator());
    }
}

/// <summary>
/// Classe de validaão de Produtos.
/// </summary>
public class ProductRequestValidator : AbstractValidator<ProductRequest>
{
    public ProductRequestValidator()
    {
        RuleFor(p => p.Id)
            .NotEmpty()
            .WithErrorCode(ErrorCode.ErroInesperado.ToCode())
            .WithMessage("Preencha o Id do Produto.");

        RuleFor(p => p.Name)
            .NotEmpty()
            .WithErrorCode(ErrorCode.ErroInesperado.ToCode())
            .WithMessage("Preencha o nome do Produto.");

        RuleFor(p => p.Description)
            .NotEmpty()
            .WithErrorCode(ErrorCode.ErroInesperado.ToCode())
            .WithMessage("Preencha a descrição do Produto.");

        RuleFor(p => p.UnitValue)
            .GreaterThan(0)
            .WithErrorCode(ErrorCode.ErroInesperado.ToCode())
            .WithMessage("O valor unitário deve ser maior que zero.");

        RuleFor(p => p.Quantity)
            .GreaterThan(0)
            .WithErrorCode(ErrorCode.ErroInesperado.ToCode())
            .WithMessage("A quantidade do produto deve ser maior que zero.");
    }
}