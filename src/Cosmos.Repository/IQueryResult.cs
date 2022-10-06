using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmos.Repository;



public interface IQueryResult<out TItem> where TItem : IItem
{
    IReadOnlyList<TItem> Items { get; }
    double Charge { get; }
}
