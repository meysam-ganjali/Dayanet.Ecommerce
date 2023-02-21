using Dayanet.Ecommerce.SharedModels.Dtos.Category;

namespace Dayanet.Ecommerce.SharedModels.Dtos.CategoryAttribute;

public class UpdateCategoryAttributeDto {
    public int Id { get; set; }
    public string AttributeName { get; set; }
    public int CategoryId { get; set; }
    public CategoryDto Category { get; set; }
}