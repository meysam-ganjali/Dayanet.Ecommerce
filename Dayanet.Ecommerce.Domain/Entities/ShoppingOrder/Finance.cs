using System.ComponentModel.DataAnnotations.Schema;
using Dayanet.Ecommerce.Domain.Entities.Auth;

namespace Dayanet.Ecommerce.Domain.Entities.ShoppingOrder;

public class Finance:BaseEntity<long>
{
    public Guid Guid { get; set; }
    public int Amount { get; set; }
    public bool IsPay { get; set; }
    public DateTime? PayDate { get; set; }
    public string Authority { get; set; }
    public long RefId { get; set; } = 0;
    //relation
    public long UserId { get; set; }
    [ForeignKey("UserId")]
    public virtual User User { get; set; }

    public virtual ICollection<Order> Orders { get; set; }
}