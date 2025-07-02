using System;
using System.Collections.Generic;
using BusinessEntities;
using Common;
using Core.Factories;
using Core.Services.Products;
using Data.Repositories;

namespace Core.Services.Orders
{
    [AutoRegister]
    public class CreateOrderService : ICreateOrderService
    {
        private readonly IUpdateOrderService _updateOrderService;
        private readonly IGetProductService _getProductService;
        private readonly IIdObjectFactory<Order> _orderFactory;
        private readonly IOrderRepository _orderRepository;

        public CreateOrderService(IIdObjectFactory<Order> orderFactory, IOrderRepository orderRepository, IUpdateOrderService updateOrderService, IGetProductService getProductService)
        {
            _orderFactory = orderFactory;
            _orderRepository = orderRepository;
            _updateOrderService = updateOrderService;
            _getProductService = getProductService;
        }

        public Order Create(Guid id, string address, List<Guid> products)
        {
            for (int i = products.Count-1; i >=0 ; i--)
            {
                var record = _getProductService.GetProduct(products[i]);

                if (record == null)
                {
                    products.RemoveAt(i);
                }
            }
            bool recordFound = products.Count > 0;

            var order = _orderFactory.Create(id);
            _updateOrderService.Update(order, address, products);
            _orderRepository.Save(order);
            return order;
        }
    }
}