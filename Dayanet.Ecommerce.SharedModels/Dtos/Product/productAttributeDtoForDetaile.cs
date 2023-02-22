using Dayanet.Ecommerce.SharedModels.Dtos.CategoryAttribute;
using Dayanet.Ecommerce.SharedModels.Dtos.Product.Get;

namespace Dayanet.Ecommerce.SharedModels.Dtos.Product;

public class productAttributeDtoForDetaile
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime? UpdateedDate { get; set; }
    public bool IsShow { get; set; }
    public int ProductId { get; set; }
    public int CategoryAttributeId { get; set; }
    public string CategoryAttributeName { get; set; }
    public  List<AttributeValueDto> AttributeValues { get; set; }
}