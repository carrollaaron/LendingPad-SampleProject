using BusinessEntities;

namespace WebApi.Models.Products
{
    public class ProductData : IdObjectData
    {
        public ProductData(Product product) : base(product)
        {
            Name = product.Name;
            Cost = product.Cost;
        }

        public string Name { get; set; }
        public decimal Cost { get; set; }
    }
}