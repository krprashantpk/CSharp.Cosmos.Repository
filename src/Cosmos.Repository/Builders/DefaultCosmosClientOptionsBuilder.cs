using Azure.Identity;
using Cosmos.Repository.Options;
using Microsoft.Azure.Cosmos;

namespace Cosmos.Repository.Builders;

public class DefaultCosmosClientOptionsBuilder
{
    internal DefaultCosmosClientOptions Options = new DefaultCosmosClientOptions();

    public DefaultCosmosClientOptions WithAccountKey(string accountKey)
    {
        Options.AccountKey = accountKey ?? throw new ArgumentNullException(nameof(accountKey));
        return Options;
    }
    public DefaultCosmosClientOptions WithAccountEndpoint(string accountEndpoint)
    {
        if (!Uri.TryCreate(accountEndpoint, UriKind.Absolute, out Uri _)) throw new ArgumentException(message: "A valid Azure Cosmos Account Endpoint is required.", paramName: nameof(accountEndpoint));
        Options.AccountEndpoint = accountEndpoint ?? throw new ArgumentNullException(nameof(accountEndpoint));
        return Options;
    }
    public DefaultCosmosClientOptions WithTokenCredential()
    {
        Options.TokenCredential = new DefaultAzureCredential();
        return Options;
    }
    public DefaultCosmosClientOptions WithDatabaseId(string databaseId)
    {
        Options.DatabaseId = databaseId ?? throw new ArgumentNullException(nameof(databaseId));
        return Options;
    }
    public DefaultCosmosClientOptions WithOptimizeBandwidth()
    {
        Options.OptimizeBandwidth = true;
        return Options;
    }
    public DefaultCosmosClientOptions WithMode(ConnectionMode mode)
    {
        Options.Mode = mode;
        return Options;
    }
    public DefaultCosmosClientOptions WithApplicationName(string applicationName)
    {
        Options.ApplicationName = applicationName;
        return Options;
    }
    public DefaultCosmosClientOptions WithApplicationPreferredRegions(string[] regions)
    {
        if (regions == null || !regions.Any()) throw new ArgumentNullException(nameof(regions));
        Options.ApplicationPreferredRegions.Clear();
        Options.ApplicationPreferredRegions.AddRange(regions);
        return Options;
    }
    public DefaultCosmosClientOptions WithRequestTimeOut(TimeSpan time)
    {
        Options.RequestTimeOut = time;
        return Options;
    }
}
