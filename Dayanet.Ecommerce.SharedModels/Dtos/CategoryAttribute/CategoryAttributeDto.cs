using System.ComponentModel.DataAnnotations.Schema;
using Dayanet.Ecommerce.SharedModels.Dtos.Category;

namespace Dayanet.Ecommerce.SharedModels.Dtos.CategoryAttribute;

public class CategoryAttributeDto
{
    public int Id { get; set; }
    public string AttributeName { get; set; }
    public int CategoryId { get; set; }
    public CategoryDto Category { get; set; }

   // public virtual ICollection<ProductAttribute> ProductAttributes { get; set; }
}