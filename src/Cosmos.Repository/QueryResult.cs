namespace Cosmos.Repository;


public class QueryResult<TItem> : IQueryResult<TItem> where TItem : IItem
{
    public QueryResult(IReadOnlyList<TItem> items, double charge)
    {
        Items = items;
        Charge = charge;
    }
    public IReadOnlyList<TItem> Items { get; }
    public double Charge { get; }
}
