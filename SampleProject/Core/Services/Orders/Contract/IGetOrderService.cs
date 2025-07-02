using System;
using System.Collections.Generic;
using BusinessEntities;

namespace Core.Services.Orders
{
    public interface IGetOrderService
    {
        Order GetOrder(Guid id);

        IEnumerable<Order> GetList(string address, List<Guid> products);
    }
}