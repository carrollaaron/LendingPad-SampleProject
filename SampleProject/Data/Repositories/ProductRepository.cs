using BusinessEntities;
using Common;
using Data.Indexes;
using Raven.Client;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repositories
{
    [AutoRegister]
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly IDocumentSession _documentSession;

        public ProductRepository(IDocumentSession documentSession) : base(documentSession)
        {
            _documentSession = documentSession;
        }
        public IEnumerable<Product> GetByTag(string tag = null)
        {
            //var query = _documentSession.Advanced.DocumentQuery<Product, ProductsListIndex>();

            if (tag != null)
            {
                //query = query.Where($"tags:*{tag}*");               //Note: Works only from Web UI
                //query = query.Where($"Name:*Andy*");              //Note: Works
                //query = query.WhereIn("Tags", new[] { $"tag" });  //Note: Alternate form
            }

            return null;// query.ToList();
        }

        public IEnumerable<Product> Get(string name = null, string email = null)
        {
            var query = _documentSession.Advanced.DocumentQuery<Product, ProductsListIndex>();

            var hasFirstParameter = false;
            //if (productType != null)
            //{
            //    query = query.WhereEquals("Type", (int)productType);
            //    hasFirstParameter = true;
            //}

            if (name != null)
            {
                if (hasFirstParameter)
                {
                    query = query.AndAlso();
                }
                else
                {
                    hasFirstParameter = true;
                }
                query = query.Where($"Name:*{name}*");
            }

            if (email != null)
            {
                if (hasFirstParameter)
                {
                    query = query.AndAlso();
                }
                query = query.WhereEquals("Email", email);
            }
            return query.ToList();
        }

        public void DeleteAll()
        {
            //base.DeleteAll<ProductsListIndex>();
        }

        public IEnumerable<Product> GetProductList(string name, decimal cost)
        {
            var query = _documentSession.Advanced.DocumentQuery<Product, ProductsListIndex>();

            var hasFirstParameter = false;
            //if (productType != null)
            //{
            //    query = query.WhereEquals("Type", (int)productType);
            //    hasFirstParameter = true;
            //}

            if (name != null)
            {
                if (hasFirstParameter)
                {
                    query = query.AndAlso();
                }
                else
                {
                    hasFirstParameter = true;
                }
                query = query.Where($"Name:*{name}*");
            }

            if (cost > 0)
            {
                if (hasFirstParameter)
                {
                    query = query.AndAlso();
                }
                query = query.WhereEquals("Cost", cost);
            }
            return query.ToList();
        }
    }
}