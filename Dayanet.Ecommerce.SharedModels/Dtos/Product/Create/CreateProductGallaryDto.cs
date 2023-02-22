using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace Dayanet.Ecommerce.SharedModels.Dtos.Product.Create;

public class CreateProductGallaryDto
{
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public bool IsShow { get; set; } = true;
    public string ImagePath { get; set; }
    public List<IFormFile> Images { get; set; }    
    public int ProductId { get; set; }
}