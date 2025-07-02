using System.Collections.Generic;
using BusinessEntities;

namespace Data.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> Get(string name = null, string email = null);
        
        IEnumerable<Product> GetList(string name, decimal cost);
    }
}