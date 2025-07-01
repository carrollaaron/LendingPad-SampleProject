using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;

namespace Data
{
    //public class ProductContext : DbContext
    //{
    //    public DbSet<ProductContext> Books { get; set; }

    //    public ProductContext(DbContextOptions<ProductContext> options)
    //        : base(options)
    //    {
    //    }
    //}

    public class ProductContext : DbContext
    {
        public ProductContext<Product> Books { get; set; }

        public ProductContext() : base("name=ProductContext")
        {
        }

        // Constructor for Effort in-memory database
        public ProductContext(System.Data.Common.DbConnection connection) : base(connection, true)
        {
        }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
