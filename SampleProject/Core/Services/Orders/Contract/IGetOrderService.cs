﻿using System;
using System.Collections.Generic;
using BusinessEntities;

namespace Core.Services.Orders
{
    public interface IGetOrderService
    {
        Order GetOrder(Guid id);

        IEnumerable<Order> GetOrders(string name = null, string email = null);

        IEnumerable<Order> GetOrdersByTag(string tag);
    }
}