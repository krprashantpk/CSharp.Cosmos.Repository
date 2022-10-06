using Cosmos.Repository.Providers;
using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmos.Repository.Repositories;

public class GenericRepository
{
    private readonly ICosmosContainerProvider containerProvider;

    public GenericRepository(ICosmosContainerProvider containerProvider)
    {
        this.containerProvider = containerProvider;
    }

    public async Task<IQueryResult<T>> GetItemAsync<T>(QueryDefinition query, CancellationToken? cancellationToken = null, QueryRequestOptions? options = null) where T : IItem
    {
        var container = await containerProvider.GetContainerAsync<T>().ConfigureAwait(false);

        container.GetItemLinqQueryable()
    }
}
