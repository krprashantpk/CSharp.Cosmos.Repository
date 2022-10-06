using Azure.Core;
using Cosmos.Repository.Options;
using Microsoft.Azure.Cosmos;

namespace Cosmos.Repository.Providers;

internal class CosmosClientProvider : ICosmosClientProvider, IDisposable
{
    Lazy<CosmosClient> client;
    private readonly CosmosClientOptionsProvider optionsProvider;

    public CosmosClientProvider(CosmosClientOptionsProvider optionsProvider)
    {

        client = new Lazy<CosmosClient>(GetCosmosClient());
        this.optionsProvider = optionsProvider;
    }

    CosmosClient GetCosmosClient()
    {
        var clientOptions = optionsProvider.Get();
        (string AccountEndPoint, string ? AccountKey, TokenCredential ? Token) = optionsProvider.GetAuthenticatingDetail();   
        return AccountKey is not null
                ? new CosmosClient($"AccountEndpoint={AccountEndPoint};AccountKey={AccountKey}", clientOptions)
                : new CosmosClient(AccountEndPoint, Token, clientOptions);
    }

    public Task UseClientAsync(Func<CosmosClient, Task> action)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));
        return action.Invoke(client.Value);
    }

    public Task<TResult> UseClientAsync<TResult>(Func<CosmosClient, Task<TResult>> action)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));
        return action.Invoke(client.Value);
    }

    public void Dispose()
    {
        if (client.IsValueCreated)
        {
            client.Value?.Dispose();
        }
    }
}
