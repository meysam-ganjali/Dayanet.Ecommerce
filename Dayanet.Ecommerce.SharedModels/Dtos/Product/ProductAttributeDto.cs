namespace Dayanet.Ecommerce.SharedModels.Dtos.Product;

public class ProductAttributeDto
{
    public int ProductId { get; set; }
    public int CategoryAttributeId { get; set; }
    public string Value { get; set; }
    public string? ColorHex { get; set; }
    public bool IsShow { get; set; } = true;
}