using FluentValidation;
using VENDAS.DOMAIN.Dtos.Request;
using VENDAS.DOMAIN.Enums;
using VENDAS.DOMAIN.Helpers.Extensions;

namespace VENDAS.DOMAIN.Validators;

/// <summary>
/// Classe de validação de venda.
/// </summary>
public class SaleRequestValidator : AbstractValidator<SaleRequest>
{
    /// <summary>
    /// ctor
    /// </summary>
    public SaleRequestValidator()
    {
        RuleFor(s => s.Client)
            .NotNull()
            .WithErrorCode(ErrorCode.ErroInesperado.ToCode())
            .WithMessage("Preencha os dados do Cliente.");

        RuleFor(s => s.Client.Id)
            .NotEmpty()
            .NotNull()
            .WithErrorCode(ErrorCode.ErroInesperado.ToCode())
            .WithMessage("Preencha o Id do Cliente.");

        RuleFor(s => s.Client.Name)
           .NotEmpty()
           .NotNull()
           .WithErrorCode(ErrorCode.ErroInesperado.ToCode())
           .WithMessage("Preencha o nome do Cliente.");

        RuleFor(s => s.Client.Email)
            .NotEmpty()
            .NotNull()
            .WithErrorCode(ErrorCode.ErroInesperado.ToCode())
            .WithMessage("Preencha o email do Cliente.");

        RuleFor(s => s.Branch)
            .NotNull()
            .WithErrorCode(ErrorCode.ErroInesperado.ToCode())
            .WithMessage("Preencha os dados da Filial.");

        RuleFor(s => s.Branch.Id)
           .NotEmpty()
           .NotNull()
           .WithErrorCode(ErrorCode.ErroInesperado.ToCode())
           .WithMessage("Preencha o Id da Filial.");

        RuleFor(s => s.Branch.Name)
          .NotEmpty()
          .NotNull()
          .WithErrorCode(ErrorCode.ErroInesperado.ToCode())
          .WithMessage("Preencha o nome da Filial.");

        RuleFor(s => s.Branch.Description)
            .NotEmpty()
            .NotNull()
            .WithErrorCode(ErrorCode.ErroInesperado.ToCode())
            .WithMessage("Preencha a descrição da Filial.");

        RuleFor(s => s.Products)
            .NotNull()
            .WithErrorCode(ErrorCode.ErroInesperado.ToCode())
            .WithMessage("Preencha os dados de Produtos.");
    }
}
