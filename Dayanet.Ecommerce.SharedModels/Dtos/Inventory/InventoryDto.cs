using System.ComponentModel.DataAnnotations.Schema;

namespace Dayanet.Ecommerce.SharedModels.Dtos.Inventory;

public class InventoryDto
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; } 
    public DateTime? UpdateedDate { get; set; }
    public bool IsShow { get; set; }
    public string SKU { get; set; } 
    public int ProductCount { get; set; }
    public DateTime? LastSellDate { get; set; }
    public int ProductId { get; set; }
}