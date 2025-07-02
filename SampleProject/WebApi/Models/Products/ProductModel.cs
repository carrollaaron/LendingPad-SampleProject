
using System;

namespace WebApi.Models.Products
{
    public class ProductModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
    }
}