namespace Dayanet.Ecommerce.SharedModels.Dtos.Category;

public class UpdateCategoryDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public bool IsShow { get; set; }
    public int? ParentCategoryId { get; set; }
}