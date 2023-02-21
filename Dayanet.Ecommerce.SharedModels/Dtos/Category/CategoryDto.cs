using System.ComponentModel.DataAnnotations.Schema;
using Dayanet.Ecommerce.SharedModels.Dtos.CategoryAttribute;

namespace Dayanet.Ecommerce.SharedModels.Dtos.Category;

public class CategoryDto {
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public int? ParentCategoryId { get; set; }
    public bool IsShow { get; set; }
    public CategoryDto ParentCategory { get; set; }
    public  List<CategoryDto> SubCategories { get; set; }
    public virtual ICollection<CategoryAttributeDto> CategoryAttributes { get; set; }
    //public virtual ICollection<Product> Products { get; set; }
}