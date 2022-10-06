using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmos.Repository
{
    public class ItemResult<TItem> : IItemResult<TItem> where TItem : IItem
    {
        public ItemResult(TItem item, double charge, string ETag)
        {
            Item = item;
            Charge = charge;
            this.ETag = ETag;
        }

        public TItem Item { get; }
        public double Charge { get; }
        public string ETag { get; }
    }
}
