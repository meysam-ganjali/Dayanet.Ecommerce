using System.ComponentModel.DataAnnotations.Schema;

namespace Dayanet.Ecommerce.Domain.Entities.Ecommerce;

public class ProductAttribute : BaseEntity {
    
    public int ProductId { get; set; }
    [ForeignKey("ProductId")]
    public virtual Product Product { get; set; }
    [ForeignKey("CategoryAttributeId")]
    public int CategoryAttributeId { get; set; }
    public virtual CategoryAttribute CategoryAttribute { get; set; }
    public virtual ICollection<AttributeValue> AttributeValues { get; set; }
}