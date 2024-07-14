using Microsoft.Extensions.Configuration;

public class Neo4jOptions(IConfigurationSection configuration)
{
    public string Url { get; set; } = configuration["Url"];
    public string Username { get; set; } = configuration["Username"];
    public string Password { get; set; } = configuration["Password"];
    public string Database { get; set; } = configuration["Database"];
}