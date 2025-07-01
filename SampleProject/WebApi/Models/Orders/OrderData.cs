using BusinessEntities;

namespace WebApi.Models.Orders
{
    public class OrderData : IdObjectData
    {
        public OrderData(Order order) : base(order)
        {
            Email = order.Email;
            Name = order.Name;
            Type = new EnumData(order.Type);
            MonthlySalary = order.MonthlySalary;
            Age = order.Age;
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public EnumData Type { get; set; }
        public decimal? MonthlySalary { get; set; }
        public int Age { get; set; }
    }
}