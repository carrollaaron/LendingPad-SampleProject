using BusinessEntities;
using Common;
using Data.Indexes;
using Raven.Client;
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
        public IEnumerable<Order> GetByTag(string tag = null)
        {
            //var query = _documentSession.Advanced.DocumentQuery<Order, OrdersListIndex>();

            if (tag != null)
            {
                //query = query.Where($"tags:*{tag}*");               //Note: Works only from Web UI
                //query = query.Where($"Name:*Andy*");              //Note: Works
                //query = query.WhereIn("Tags", new[] { $"tag" });  //Note: Alternate form
            }

            return null;// query.ToList();
        }

        //public IEnumerable<Order> Get(OrderTypes? orderType = null, string name = null, string email = null)
        //{
        //    var query = _documentSession.Advanced.DocumentQuery<Order, OrdersListIndex>();

        //    var hasFirstParameter = false;
        //    if (orderType != null)
        //    {
        //        query = query.WhereEquals("Type", (int)orderType);
        //        hasFirstParameter = true;
        //    }

        //    if (name != null)
        //    {
        //        if (hasFirstParameter)
        //        {
        //            query = query.AndAlso();
        //        }
        //        else
        //        {
        //            hasFirstParameter = true;
        //        }
        //        query = query.Where($"Name:*{name}*");
        //    }

        //    if (email != null)
        //    {
        //        if (hasFirstParameter)
        //        {
        //            query = query.AndAlso();
        //        }
        //        query = query.WhereEquals("Email", email);
        //    }
        //    return query.ToList();
        //}

        public void DeleteAll()
        {
            //base.DeleteAll<OrdersListIndex>();
        }

        public IEnumerable<User> Get(UserTypes? userType = null, string name = null, string email = null)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Order> Get(string name = null, string email = null)
        {
            throw new System.NotImplementedException();
        }
    }
}