using Cosmos.Repository.Options;
using Microsoft.Azure.Cosmos;

namespace Cosmos.Repository.Providers;

internal class CosmosContainerProvider : ICosmosContainerProvider
{
    private readonly ICosmosClientProvider clientProvider;
    private readonly CosmosRepositoryOptions options;

    public CosmosContainerProvider(ICosmosClientProvider clientProvider, CosmosRepositoryOptions options)
    {
        this.clientProvider = clientProvider;
        this.options = options;
    }

    public async Task<Container> GetContainerAsync<TItem>() where TItem : IItem
    {
        Database database = options.CreateIfNotExist
                                ? await clientProvider.UseClientAsync(client => client.CreateDatabaseIfNotExistsAsync(options.DatabaseId)).ConfigureAwait(false)
                                : await clientProvider.UseClientAsync(client => Task.FromResult(client.GetDatabase(options.DatabaseId)));

        var containerOption = options.GetContainerConfiguration<TItem>();

        ContainerProperties containerProperties = new()
        {
            Id = containerOption.Name,
            PartitionKeyPath = containerOption.PartitionKey,
            UniqueKeyPolicy = new(),
            DefaultTimeToLive = containerOption.TimeToLive,
        };

        Container container = options.CreateIfNotExist
                        ? await database.CreateContainerIfNotExistsAsync(containerProperties, containerOption.ThroughputProperties).ConfigureAwait(false)
                        : await Task.FromResult(database.GetContainer(containerProperties.Id));

        return container;
    }
}
