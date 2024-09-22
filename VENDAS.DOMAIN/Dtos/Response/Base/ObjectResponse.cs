using Microsoft.AspNetCore.Mvc;

namespace VENDAS.DOMAIN.Dtos.Response.Base;

/// <summary>
/// Objeto de retorno.
/// </summary>
public class ObjectResponse : ObjectResult
{
    /// <summary>
    /// ctor.
    /// </summary>
    /// <param name="statusCode"></param>
    /// <param name="value"></param>
    public ObjectResponse(
        int statusCode, 
        object value) : base(value)
    {
        StatusCode = statusCode;
    }
}
