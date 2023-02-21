using System.ComponentModel.DataAnnotations.Schema;
using Dayanet.Ecommerce.Domain.Entities.Auth;

namespace Dayanet.Ecommerce.Domain.Entities.ShoopingCart;

public class Cart:BaseEntity<long>
{
    public Guid BrowserId { get; set; }
    public bool Finished { get; set; }

    public int SumProducts { get; set; }
    //relation
    public long UserId { get; set; }
    [ForeignKey("UserId")]
    public virtual User User { get; set; }

    public virtual ICollection<CartItem> CartItems { get; set; }
}