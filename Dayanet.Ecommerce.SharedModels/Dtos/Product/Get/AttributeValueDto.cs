namespace Dayanet.Ecommerce.SharedModels.Dtos.Product.Get;

public class AttributeValueDto
{

    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdateedDate { get; set; }
    public bool IsShow { get; set; }
    public string Value { get; set; }
    public string? ColorHex { get; set; }
    public int ProductAttributeId { get; set; }
}