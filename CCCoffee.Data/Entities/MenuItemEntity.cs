namespace CCCoffee.Data.Entities
{
    public class MenuItemEntity
    {
     public int MenuItemId { get; set; }

    public string MealName { get; set; } = null!;

    public string MealDescription { get; set; } = null!;

    public decimal MealPrice { get; set; }

    private string OrderId {get; set;}
    } 
}