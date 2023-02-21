using System.ComponentModel.DataAnnotations.Schema;
using Dayanet.Ecommerce.SharedModels.Dtos.Category;
using Microsoft.AspNetCore.Http;

namespace Dayanet.Ecommerce.SharedModels.Dtos.Product.Create;

public class CreateProductDto
{
    public DateTime CreatedDate { get; set; }
    public bool IsShow { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
    public string? ImageCoverPath { get; set; }
    public IFormFile Image { get; set; }
    public string ShortDescription { get; set; }
    public string? FullDescription { get; set; }
    public bool IsSotialProduct { get; set; }
    public bool ShowOnHomepage { get; set; }
    public bool AllowCustomerComment { get; set; }
    public int? Weight { get; set; }
    public int? Length { get; set; }
    public int? Width { get; set; }
    public int? Height { get; set; }
    public int CategoryId { get; set; }
}