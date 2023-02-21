using System.ComponentModel.DataAnnotations.Schema;
using Dayanet.Ecommerce.Domain.Entities.Ecommerce;

namespace Dayanet.Ecommerce.Domain.Entities.ShoppingOrder;

public class ProductCostType:BaseEntity
{
    public int CostId { get; set; }
    [ForeignKey("CostId")]
    public virtual Cost Cost { get; set; }
    public int ProductId { get; set; }
    [ForeignKey("ProductId")]
    public virtual Product Product { get; set; }
}