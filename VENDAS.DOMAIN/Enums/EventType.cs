using System.ComponentModel;

namespace VENDAS.DOMAIN.Enums;

// <summary>
/// Enum que representa os tipos de eventos.
/// </summary>
public enum EventType
{
    [Description("Compra Criada")]
    CompraCriada = 1,

    [Description("Compra Alterada")]
    CompraAlterada = 2,

    [Description("Compra Cancelada")]
    CompraCancelada = 3,
}