using System.ComponentModel.DataAnnotations.Schema;

namespace Dayanet.Ecommerce.Domain.Entities.Ecommerce;

public class Category : BaseEntity {
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public int? ParentCategoryId { get; set; }
    //Relation
    [ForeignKey("ParentCategoryId")] 
    public virtual Category ParentCategory { get; set; }

    //برای نمایش زیر دسته های هر گروه
    public virtual ICollection<Category> SubCategories { get; set; }
    public virtual ICollection<CategoryAttribute> CategoryAttributes { get; set; }
    public virtual ICollection<Product> Products { get; set; }

}