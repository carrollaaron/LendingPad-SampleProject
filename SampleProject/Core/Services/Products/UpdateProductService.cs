using BusinessEntities;
using Common;
using Core.Services.Products;

namespace Core.Services.Products
{
    [AutoRegister(AutoRegisterTypes.Singleton)]
    public class UpdateProductService : IUpdateProductService
    {
        public void Update(Product order, string name, decimal cost)
        {            
            order.SetName(name);
            order.SetCost(cost);
        }
    }
}