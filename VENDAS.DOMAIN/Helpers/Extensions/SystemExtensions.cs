using Newtonsoft.Json;

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
}

