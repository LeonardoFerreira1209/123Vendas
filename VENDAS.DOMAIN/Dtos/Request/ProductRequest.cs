﻿namespace VENDAS.DOMAIN.Dtos.Request;

/// <summary>
/// Objeto de transporte de dados de request de produto.
/// </summary>
public class ProductRequest
{
    /// <summary>
    /// Identificador.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Nome.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Descrição.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Valor unitário.
    /// </summary>
    public decimal UnitValue { get; set; }

    /// <summary>
    /// Quantidade.
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Desconto.
    /// </summary>
    public decimal Discount { get; set; }
}
