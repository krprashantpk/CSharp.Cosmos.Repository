using Microsoft.Azure.Cosmos;

namespace Cosmos.Repository.Providers
{
    public interface ICosmosContainerProvider
    {
        Task<Container> GetContainerAsync<TItem>() where TItem : IItem;
    }
}