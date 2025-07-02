using System;
using System.Collections.Generic;

namespace WebApi.Models.Orders
{
    public class OrderModel
    {
        public string Address { get; set; }

        public List<Guid> Products { get; set; }
    }
}