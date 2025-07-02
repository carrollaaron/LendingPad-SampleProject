using BusinessEntities;
using Common;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Core.Services.Orders
{
    [AutoRegister]
    public class GetOrderService : IGetOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Order GetOrder(Guid id)
        {
            return _orderRepository.Get(id);
        }

        public IEnumerable<Order> GetList(string address, List<Guid> products)
        {
            return _orderRepository.GetList(address);
        }
    }
}