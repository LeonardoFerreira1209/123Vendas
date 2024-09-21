namespace VENDAS.DOMAIN.Dtos.Configurations;

/// <summary>
/// Classe responsavel por receber os dados do Appsettings.
/// </summary>
public sealed class AppSettings
{
    public ConnectionStrings ConnectionStrings { get; set; }
    public ServiceBus ServiceBus { get; set; }
}

/// <summary>
/// Classe de conexões.
/// </summary>
public sealed class ConnectionStrings
{
    public string DataBase { get; set; }
    public string AzureBlobStorage { get; set; }
}

/// <summary>
/// Classe de config do service bus.
/// </summary>
public sealed class ServiceBus
{
    /// <summary>
    /// String de conexão do service bus.
    /// </summary>
    public string ConnectionString { get; set; }
}
