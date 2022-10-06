using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmos.Repository
{
    public interface IItemResult<TItem> where TItem : IItem
    {
        TItem Item { get; }
        public string ETag { get; }
        double Charge { get; }
    }
}
