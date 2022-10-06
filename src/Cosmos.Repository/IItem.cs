namespace Cosmos.Repository;

public interface IItem
{
    public string Id { get; }
    public string PartitionKey { get; }
}

