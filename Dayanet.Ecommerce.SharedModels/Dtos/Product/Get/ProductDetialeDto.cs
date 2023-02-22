using Dayanet.Ecommerce.SharedModels.Dtos.ProductGallery;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dayanet.Ecommerce.SharedModels.Dtos.Product.Get;

public class ProductDetialeDto
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime CreatedInventoryDate { get; set; }
    public DateTime? UpdateInventoryDate { get; set; }
    public DateTime? LastSellDate { get; set; }
    public DateTime? UpdateedDate { get; set; }
    public bool IsShow { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
    public string? ImageCoverPath { get; set; }
    public string ShortDescription { get; set; }
    public string? FullDescription { get; set; }
    public int ShowCount { get; set; }
    public bool IsSotialProduct { get; set; }
    public int Rate { get; set; }
    public bool ShowOnHomepage { get; set; }
    public bool AllowCustomerComment { get; set; }
    public int? Weight { get; set; }
    public int? Length { get; set; }
    public int? Width { get; set; }
    public int? Height { get; set; }
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
    public string ParentName { get; set; }
    public int ProductCount { get; set; }
    public string SKU{ get; set; }
    public List<ProductGalleryDto> Galleries { get; set; }
    public List<productAttributeDtoForDetaile> Attributes { get; set; }
}