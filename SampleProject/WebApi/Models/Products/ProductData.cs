using BusinessEntities;

namespace WebApi.Models.Products
{
    public class ProductData : IdObjectData
    {
        public ProductData(Product product) : base(product)
        {
            Email = product.Email;
            Name = product.Name;
            Type = new EnumData(product.Type);
            MonthlySalary = product.MonthlySalary;
            Age = product.Age;
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public EnumData Type { get; set; }
        public decimal? MonthlySalary { get; set; }
        public int Age { get; set; }
    }
}