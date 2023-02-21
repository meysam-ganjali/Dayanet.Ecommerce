using System.ComponentModel.DataAnnotations.Schema;
using Dayanet.Ecommerce.Domain.Entities.Ecommerce;

namespace Dayanet.Ecommerce.Domain.Entities.ShoppingOrder;

public class OrderDetaile:BaseEntity<long> {
    public int Quantity { get; set; }
    public int ProductPrice { get; set; }
    public int SumProductPrice { get; set; }
    public long OrderId { get; set; }
    [ForeignKey("OrderId")] 
    public virtual Order Order { get; set; }
    public int ProductId { get; set; }
    [ForeignKey("ProductId")]
    public virtual Product Product { get; set; }
}