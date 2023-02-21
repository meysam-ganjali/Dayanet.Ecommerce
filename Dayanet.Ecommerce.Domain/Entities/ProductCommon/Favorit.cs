using Dayanet.Ecommerce.Domain.Entities.Auth;
using Dayanet.Ecommerce.Domain.Entities.Ecommerce;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dayanet.Ecommerce.Domain.Entities.ProductCommon;

public class Favorit : BaseEntity {
    public int ProductId { get; set; }
    [ForeignKey("ProductId")]
    public virtual Product Product { get; set; }

    public long UserId { get; set; }
    [ForeignKey("UserId")]
    public virtual User User { get; set; }
}