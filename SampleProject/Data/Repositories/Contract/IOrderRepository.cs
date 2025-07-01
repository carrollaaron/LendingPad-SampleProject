using System.Collections.Generic;
using BusinessEntities;

namespace Data.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        IEnumerable<User> Get(UserTypes? userType = null, string name = null, string email = null);
        void DeleteAll();
        IEnumerable<User> GetByTag(string tag = null);
    }
}