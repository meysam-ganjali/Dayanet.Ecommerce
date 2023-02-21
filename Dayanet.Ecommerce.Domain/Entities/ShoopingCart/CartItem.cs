using System.ComponentModel.DataAnnotations.Schema;
using Dayanet.Ecommerce.Domain.Entities.Ecommerce;

namespace Dayanet.Ecommerce.Domain.Entities.ShoopingCart;

public class CartItem : BaseEntity<long>{
    public int Quantity { get; set; }
    public int Price { get; set; }
    //relation
    public long CartId { get; set; }
    [ForeignKey("CartId")]
    public virtual Cart Cart { get; set; }

    public int ProductId { get; set; }
    [ForeignKey("ProductId")]
    public virtual Product Product { get; set; }
}