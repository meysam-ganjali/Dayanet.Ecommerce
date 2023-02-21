using System.ComponentModel.DataAnnotations.Schema;

namespace Dayanet.Ecommerce.Domain.Entities.Ecommerce;

public class AttributeValue : BaseEntity {
    public string Value { get; set; }
    public string? ColorHex { get; set; }
    public int ProductAttributeId { get; set; }
    [ForeignKey("ProductAttributeId")]
    public virtual ProductAttribute ProductAttribute { get; set; }
}