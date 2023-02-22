using System.ComponentModel.DataAnnotations.Schema;

namespace Dayanet.Ecommerce.Domain.Entities.Ecommerce;

public class CategoryAttribute : BaseEntity {
    public string AttributeName { get; set; }
    public int CategoryId { get; set; }
    //Relation
    [ForeignKey("CategoryId")] 
    public virtual Category Category { get; set; }

    public virtual ICollection<ProductAttribute> ProductAttributes { get; set; }

}