using Newtonsoft.Json;
using VENDAS.DOMAIN.Enums;

namespace VENDAS.DOMAIN.Helpers.Extensions;

/// <summary>
/// Classe de extensão.
/// </summary>
public static class SystemExtensions
{
    /// <summary>
    /// Serializa objeto ignorando objetos nulos.
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public static string SerializeIgnoreNullValues(this object item)
    {
        var jsonSerializerSettings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };

        return JsonConvert.SerializeObject(item, jsonSerializerSettings);
    }

    /// <summary>
    /// Obtem o código de um Enum
    /// </summary>
    /// <param name="valor"></param>
    /// <returns></returns>
    public static string ToCode(this ErrorCode valor)
    {
        return valor.GetHashCode().ToString();
    }
}

