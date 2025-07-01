using System.Collections.Generic;
using BusinessEntities;

namespace WebApi.Models.Products
{
    public class ProductModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public UserTypes Type { get; set; }
        public int Age { get; set; }
        public decimal? AnnualSalary { get; set; }
        public IEnumerable<string> Tags { get; set; }
    }
}