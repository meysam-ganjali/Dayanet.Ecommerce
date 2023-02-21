using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dayanet.Ecommerce.Domain.Entities.Ecommerce;

public class Inventory : BaseEntity
{

    public string SKU { get; set; } = Guid.NewGuid().ToString();
    public int ProductCount { get; set; }
    public DateTime? LastSellDate { get; set; }
    
    public int ProductId { get; set; }
    [ForeignKey("ProductId")]
    public Product Product { get; set; }

}