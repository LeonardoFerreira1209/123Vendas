using FluentValidation;
using VENDAS.DOMAIN.Dtos.Request;
using VENDAS.DOMAIN.Enums;
using VENDAS.DOMAIN.Helpers.Extensions;

namespace VENDAS.DOMAIN.Validators;

/// <summary>
/// Classe de validação de venda.
/// </summary>
public class SaleUpdateRequestValidator : AbstractValidator<SaleUpdateRequest>
{
    /// <summary>
    /// ctor
    /// </summary>
    public SaleUpdateRequestValidator()
    {
        RuleFor(s => s.Id)
          .NotNull()
          .NotEmpty()
          .WithErrorCode(ErrorCode.ErroInesperado.ToCode())
          .WithMessage("Preencha o Id da Venda.");
    }
}
