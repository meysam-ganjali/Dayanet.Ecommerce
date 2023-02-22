using System.ComponentModel.DataAnnotations.Schema;

namespace Dayanet.Ecommerce.SharedModels.Dtos.ProductGallery;

public class ProductGalleryDto
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdateedDate { get; set; }
    public bool IsShow { get; set; }
    public string ImagePath { get; set; }
    public int ProductId { get; set; }
}