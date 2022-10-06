namespace Cosmos.Repository;

public abstract class ItemWithTimeStamps : Item
{
    public DateTime? CreatedTimeUtc { get; internal set; }
    public DateTime? LastUpdatedTimeUtc { get; internal set; }
    public long LastUpdatedTimeRaw { get; internal set; }

}
