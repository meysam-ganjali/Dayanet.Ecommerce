using Dayanet.Ecommerce.SharedModels.Dtos.Category;

namespace Dayanet.Ecommerce.SharedModels.Dtos.CategoryAttribute;

public class CreateCategoryAttributeDto
{
    public string AttributeName { get; set; }
    public int CategoryId { get; set; }
    public bool IsShow { get; set; }
    public CategoryDto Category { get; set; }
}