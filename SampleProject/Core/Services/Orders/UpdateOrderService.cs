using BusinessEntities;
using Common;
using Core.Services.Products;
using System;
using System.Collections.Generic;

namespace Core.Services.Orders
{
    [AutoRegister]
    public class UpdateOrderService : IUpdateOrderService
    {
        private readonly IGetProductService _getProductService;

        public UpdateOrderService(IGetProductService getProductService)
        {
            _getProductService = getProductService;
        }
        public void Update(Order order, string address, List<Guid> products)
        {
            for (int i = products.Count - 1; i >= 0; i--)
            {
                var record = _getProductService.GetProduct(products[i]);

                if (record == null)
                {
                    products.RemoveAt(i);
                }
            }
            bool recordFound = products.Count > 0;
            
            
            order.SetProducts(products);
            order.SetAddress(address);
        }
    }
}