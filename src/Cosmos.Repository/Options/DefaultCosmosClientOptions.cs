using Azure.Core;
using Microsoft.Azure.Cosmos;

namespace Cosmos.Repository.Options;

public class DefaultCosmosClientOptions
{
    public string AccountEndpoint { get; internal set; }
    public TokenCredential? TokenCredential { get; internal set; }
    public string? AccountKey { get; internal set; }
    public string? ApplicationName { get; internal set; }
    public string? DatabaseId { get; internal set; } = "CSharp.Blogs";
    public bool OptimizeBandwidth { get; internal set; } = false;
    public ConnectionMode Mode { get; internal set; } = ConnectionMode.Direct;
    public List<string> ApplicationPreferredRegions { get; } = new List<string>();
    public TimeSpan RequestTimeOut { get; internal set; } = TimeSpan.FromMinutes(1);
    public ConsistencyLevel ConsistencyLevel { get; internal set; } = ConsistencyLevel.Session;
}
