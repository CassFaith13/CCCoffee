namespace CCCoffee.Data.Entities
{
    public class CustomerEntity
    {
        public string CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime ProfileCreated { get; set; }
        public DateTime CustomerBirthday { get; set; }
        public virtual ICollection<CustomerOrderEntity> CustomerOrders { get; } = new List<CustomerOrderEntity>();
    }
}
