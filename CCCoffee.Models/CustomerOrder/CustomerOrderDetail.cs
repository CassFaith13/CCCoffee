namespace CCCoffee.Models.CustomerOrder
{
    public class CustomerOrderDetail
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerFirstName { get; set; } = null!;
        public string CustomerLastName { get; set; } = null!;
        public string MealName { get; set; } = null!;
    }
}