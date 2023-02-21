using System.ComponentModel.DataAnnotations.Schema;
using Dayanet.Ecommerce.Domain.Entities.ProductCommon;
using Dayanet.Ecommerce.Domain.Entities.ShoopingCart;
using Dayanet.Ecommerce.Domain.Entities.ShoppingOrder;

namespace Dayanet.Ecommerce.Domain.Entities.Ecommerce;

public class Product : BaseEntity {

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
    //Relation
    public int CategoryId { get; set; }
    [ForeignKey("CategoryId")] public virtual Category Category { get; set; }

    public virtual Inventory Inventory { get; set; }
    public virtual ICollection<ProductCostType> ProductCostTypes { get; set; }
    public virtual ICollection<ProductAttribute> ProductAttributes { get; set; }
    public virtual ICollection<ProductGallery> ProductGalleries { get; set; }
    public virtual ICollection<CartItem> CartItems { get; set; }
    public virtual ICollection<OrderDetaile> OrderDetailes { get; set; }
    public virtual ICollection<Favorit> Favorits { get; set; }
    public virtual ICollection<Comment> Comments { get; set; }
}