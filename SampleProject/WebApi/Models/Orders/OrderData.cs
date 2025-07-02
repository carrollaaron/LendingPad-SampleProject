using BusinessEntities;
using System;
using System.Collections.Generic;

namespace WebApi.Models.Orders
{
    public class OrderData : IdObjectData
    {
        public OrderData(Order order) : base(order)
        {
            Products = order.Products;
            Address = order.Address;
        }

        public string Address { get; set; }
        public List<Guid> Products { get; set; }

    }
}