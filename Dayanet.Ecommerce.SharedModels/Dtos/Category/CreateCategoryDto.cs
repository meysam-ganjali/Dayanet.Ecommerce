namespace Dayanet.Ecommerce.SharedModels.Dtos.Category;

public class CreateCategoryDto
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public bool IsShow { get; set; }
    public int? ParentCategoryId { get; set; }
}