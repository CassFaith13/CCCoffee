namespace CCCoffee.Data.Entities
{
    public class CustomerOrderEntity
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }
        public int MenuItemId { get; set; }
        public virtual CustomerEntity Customer { get; set; }
        public virtual MenuItemEntity MenuItem { get; set; }
    }
}