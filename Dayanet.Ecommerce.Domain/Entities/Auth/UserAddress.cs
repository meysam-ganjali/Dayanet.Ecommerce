using System.ComponentModel.DataAnnotations.Schema;
using Dayanet.Ecommerce.Domain.Entities.ShoppingOrder;

namespace Dayanet.Ecommerce.Domain.Entities.Auth;

public class UserAddress:BaseEntity<long>
{
    public string Address { get; set; }
    public long UserId { get; set; }
    [ForeignKey("UserId")]
    public virtual User User { get; set; }

    public virtual ICollection<Order> Orders{ get; set; }
}