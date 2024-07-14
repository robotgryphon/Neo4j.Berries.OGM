using System.Reflection;
using Neo4j.Berries.OGM.Contexts;
using Microsoft.Extensions.DependencyInjection;
using Neo4j.Berries.OGM.Models.Config;
using Microsoft.Extensions.Options;
using Neo4j.Driver;
using System;

namespace Neo4j.Berries.OGM;

public static class DI
{
    public static IServiceCollection AddNeo4j<TContext>(this IServiceCollection services, Action<OGMConfigurationBuilder> options)
    where TContext : GraphContext
    {
        services.AddSingleton(sp =>
        {
            var configurationBuilder = new OGMConfigurationBuilder(sp);
            options(configurationBuilder);
            return new Neo4jSingletonContext(configurationBuilder);
        });

        services.AddScoped(sp =>
        {
            var neo4jOptions = sp.GetRequiredService<IOptions<Neo4jOptions>>().Value;
            sp.GetRequiredService<Neo4jSingletonContext>();

            return Activator.CreateInstance(typeof(TContext), neo4jOptions) as TContext;
        });
        return services;
    }
}