using System.Linq;
using BusinessEntities;
using Raven.Abstractions.Indexing;
using Raven.Client.Indexes;

namespace Data.Indexes
{
    public class OrdersListIndex : AbstractIndexCreationTask<Order>
    {
        public OrdersListIndex()
        {
            Map = orders => from order in orders
                           select new
                                  {
                                      order.Address,
                                     // order.Products
                                  };

            Index(x => x.Products, FieldIndexing.NotAnalyzed);
        }
    }
}