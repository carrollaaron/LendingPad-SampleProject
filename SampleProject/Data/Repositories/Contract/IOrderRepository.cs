using System.Collections.Generic;
using BusinessEntities;

namespace Data.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        IEnumerable<Order> Get(string name = null, string email = null);
        void DeleteAll();
        IEnumerable<Order> GetByTag(string tag = null);
    }
}