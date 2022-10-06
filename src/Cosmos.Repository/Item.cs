namespace Cosmos.Repository;


public abstract class Item : IItem
{
    public string Id { get; protected set; } = Guid.NewGuid().ToString();
    public string PartitionKey => GetPartitionKeyValue();
    public virtual string GetPartitionKeyValue() => Id;

}
