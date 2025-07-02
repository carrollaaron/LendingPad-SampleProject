using BusinessEntities;
using Common;
using Data.Indexes;
using Raven.Client;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repositories
{
    [AutoRegister]
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private readonly IDocumentSession _documentSession;

        public OrderRepository(IDocumentSession documentSession) : base(documentSession)
        {
            _documentSession = documentSession;
        }

        public IEnumerable<Order> GetList(string address)
        {
            var query = _documentSession.Advanced.DocumentQuery<Order, OrdersListIndex>();

            var hasFirstParameter = false;

            if (address != null)
            {
                if (hasFirstParameter)
                {
                    query = query.AndAlso();
                }
                else
                {
                    hasFirstParameter = true;
                }
                query = query.Where($"address:*{address}*");
            }

            return query.ToList();
        }
    }
}