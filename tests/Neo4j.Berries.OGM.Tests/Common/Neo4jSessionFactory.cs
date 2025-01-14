using Neo4j.Driver;

namespace Neo4j.Berries.OGM.Tests.Common;

public class Neo4jSessionFactory
{
    private static IDriver _neo4jDriver;
    public static IDriver Neo4jDriver
    {
        get
        {
            if (_neo4jDriver == null)
            {
                var neo4jOptions = new Neo4jOptions(ConfigurationsFactory.Config.GetSection("Neo4j"));
                _neo4jDriver = GraphDatabase.Driver(neo4jOptions.Url, AuthTokens.Basic(neo4jOptions.Username, neo4jOptions.Password));
            }
            return _neo4jDriver;
        }
    }
    public static void OpenSession(Action<IAsyncSession> callback)
    {
        var options = new Neo4jOptions(ConfigurationsFactory.Config.GetSection("Neo4j"));
        using var asyncSession = Neo4jDriver.AsyncSession(opt =>
        {
            if (!string.IsNullOrEmpty(options.Database))
                opt.WithDatabase(options.Database);
        });
        callback(asyncSession);
    }
}