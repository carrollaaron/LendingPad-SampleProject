using BusinessEntities;
using Common;
using Core.Services.Orders;

namespace Core.Services.Orders
{
    [AutoRegister(AutoRegisterTypes.Singleton)]
    public class UpdateOrderService : IUpdateOrderService
    {
        public void Update(Order order, string name, string email)
        {
            order.SetEmail(email);
            order.SetName(name);
        }
    }
}