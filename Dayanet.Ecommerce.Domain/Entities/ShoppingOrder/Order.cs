using System.ComponentModel.DataAnnotations.Schema;
using Dayanet.Ecommerce.Domain.Entities.Auth;

namespace Dayanet.Ecommerce.Domain.Entities.ShoppingOrder;

public class Order:BaseEntity<long> {

    public int Amount { get; set; }
    public OrderState OrderState { get; set; }
    public long UserAddressId { get; set; }
    [ForeignKey("UserAddressId")]
    public virtual UserAddress UserAddress { get; set; }
    public long UserId { get; set; }
    [ForeignKey("UserId")]
    public virtual User User { get; set; }

    public long FinanceId { get; set; }
    [ForeignKey("FinanceId")]
    public virtual Finance Finance { get; set; }

    public virtual ICollection<OrderDetaile> OrderDetailes { get; set; }
}

public enum OrderState
{
    FINISHIED,
    CANCELED,
    DELIVERID,
    PROCESSING
}