namespace Dayanet.Ecommerce.SharedModels.Dtos.Product.Create;

public class CreateInventoryDto
{
    public string SKU { get; set; } = Guid.NewGuid().ToString();
    public int ProductCount { get; set; }
    public DateTime CreatedDate { get; set; }
    public int ProductId { get; set; }
}