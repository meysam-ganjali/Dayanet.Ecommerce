namespace Dayanet.Ecommerce.Domain.Entities.ShoppingOrder;

public class Cost:BaseEntity
{
    public string Name { get; set; }
    public int CostNumber { get; set; }
    public virtual ICollection<ProductCostType> ProductCostTypes { get; set; }
}