using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CCCoffee.Data.Entities
{
    public class CustomerOrderEntity
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public int CustomerId { get; set; }
        [ForeignKey(nameof(MenuItemId))]
        public int MenuItemId { get; set; }
        public virtual CustomerEntity Customer { get; set; }
        public virtual MenuItemEntity MenuItem { get; set; }
    }
}