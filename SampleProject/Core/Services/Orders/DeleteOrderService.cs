using BusinessEntities;
using Common;
using Core.Services.Orders;
using Data.Repositories;

namespace Core.Services.Orders
{
    [AutoRegister]
    public class DeleteOrderService : IDeleteOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public DeleteOrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public void Delete(Order order)
        {
            _orderRepository.Delete(order);
        }
    }
}