using System;
using System.Collections.Generic;
using BusinessEntities;
using Common;
using Data.Repositories;

namespace Core.Services.Orders
{
    [AutoRegister]
    public class GetOrderService : IGetOrderService
    {
        private readonly IOrderRepository _userRepository;

        public GetOrderService(IOrderRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Order GetOrder(Guid id)
        {
            return null; //todo: _userRepository.Get(id);
        }

        public IEnumerable<Order> GetOrders(string name = null, string email = null)
        {
            return null; //todo: _userRepository.Get(userType, name, email);
        }

        public IEnumerable<Order> GetOrdersByTag(string tag)
        {
            return null; //todo: _userRepository.GetByTag(tag);
        }
    }
}