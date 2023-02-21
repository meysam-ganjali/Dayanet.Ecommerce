using System.ComponentModel.DataAnnotations.Schema;

namespace Dayanet.Ecommerce.Domain.Entities.Ecommerce;

public class ProductGallery : BaseEntity {
    public string ImagePath { get; set; }
    public int ProductId { get; set; }
    [ForeignKey("ProductId")]
    public virtual Product Product { get; set; }

}