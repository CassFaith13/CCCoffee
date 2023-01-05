using System.ComponentModel.DataAnnotations;

namespace CCCoffee.Data.Entities
{
    public class CustomerEntity
    {
        [Key]
        public string? CustomerId { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        public DateTime ProfileCreated { get; set; }
        [Required]
        public DateTime CustomerBirthday { get; set; }
        public virtual ICollection<CustomerOrderEntity> CustomerOrders { get; } = new List<CustomerOrderEntity>();
    }
}
