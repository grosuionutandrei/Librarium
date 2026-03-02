namespace Librarium.Data.infrastructure.configuration;

public class AppInfrastructureOptions
{
    public const string SectionName = "AppInfrastructureOptions";

    /// <summary>
    /// Database connection string
    /// </summary>
    public string ConnectionString { get; set; } = string.Empty;

    /// <summary>
    /// Database provider type (SqlServer, PostgreSQL, etc.)
    /// </summary>
    public string DatabaseProvider { get; set; } = "SqlServer";
}