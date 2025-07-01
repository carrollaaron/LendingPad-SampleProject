using BusinessEntities;
using Common;
using Data.Indexes;
using Raven.Client;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repositories
{
    [AutoRegister]
    public class InMemoryUserRepository : Repository<User>, IUserRepository
    {
        private readonly IDocumentSession _documentSession;

        public InMemoryUserRepository(IDocumentSession documentSession) : base(documentSession)
        {
            _documentSession = documentSession;
        }
        public IEnumerable<User> GetByTag(string tag = null)
        {
            var query = _documentSession.Advanced.DocumentQuery<User, UsersListIndex>();

            if (tag != null)
            {
                query = query.Where($"tags:*{tag}*");               //Note: Works only from Web UI
                //query = query.Where($"Name:*Andy*");              //Note: Works
                //query = query.WhereIn("Tags", new[] { $"tag" });  //Note: Alternate form
            }

            return query.ToList();
        }

        public IEnumerable<User> Get(UserTypes? userType = null, string name = null, string email = null)
        {
            var query = _documentSession.Advanced.DocumentQuery<User, UsersListIndex>();

            var hasFirstParameter = false;
            if (userType != null)
            {
                query = query.WhereEquals("Type", (int)userType);
                hasFirstParameter = true;
            }

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
            base.DeleteAll<UsersListIndex>();
        }
    }
}