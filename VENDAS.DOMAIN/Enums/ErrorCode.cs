﻿using System.ComponentModel;

namespace VENDAS.DOMAIN.Enums;

/// <summary>
/// Enum de códigos de erro no sistema.
/// </summary>
public enum ErrorCode
{
    /// <summary>
    /// Erro inesperado.
    /// </summary>
    [Description("Desculpe, tivemos um problema ao processar essa requisição.")]
    ErroInesperado = 500,

    /// <summary>
    /// Erro de Bad Request.
    /// </summary>
    [Description("Campos obrigatórios não informado.")]
    CamposObrigatorios = 400,
}
