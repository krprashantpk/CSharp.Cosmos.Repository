using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmos.Repository.Providers;

/// <summary>
/// Exponse a shared cosmos client. 
/// </summary>
internal interface ICosmosClientProvider
{
    Task UseClientAsync(Func<CosmosClient, Task> action);
    Task<TResult> UseClientAsync<TResult>(Func<CosmosClient, Task<TResult>> action);
}
