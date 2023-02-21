using Dayanet.Ecommerce.Domain.Entities.Auth;
using Dayanet.Ecommerce.Domain.Entities.Common;
using Dayanet.Ecommerce.Domain.Entities.Ecommerce;
using Dayanet.Ecommerce.Domain.Entities.ProductCommon;
using Dayanet.Ecommerce.Domain.Entities.ShoopingCart;
using Dayanet.Ecommerce.Domain.Entities.ShoppingOrder;
using Microsoft.EntityFrameworkCore;

namespace Dayanet.Ecommerce.Application.Context;

public interface IDataBaseContext {
    //Auth Model
    DbSet<Role> Roles { get; set; }
    DbSet<User> Users { get; set; }
    DbSet<UserAddress> UserAddresses { get; set; }
    //Common Model
    DbSet<Possition> Possitions { get; set; }
    DbSet<Banner> Banners { get; set; }
    DbSet<Slider> Sliders { get; set; }
    //Ecommerce Model
    DbSet<AttributeValue> AttributeValues { get; set; }
    DbSet<Category> Categories { get; set; }
    DbSet<CategoryAttribute> CategoryAttributes { get; set; }
    DbSet<Inventory> Inventories { get; set; }
    DbSet<Product> Products { get; set; }
    DbSet<ProductAttribute> ProductAttributes { get; set; }
    DbSet<ProductGallery> ProductGalleries { get; set; }
    //Product Common
    DbSet<Favorit> Favorits { get; set; }
    DbSet<Comment> Comments { get; set; }
    //Shoping Cart
    DbSet<Cart> Carts { get; set; }
    DbSet<CartItem> CartItems { get; set; }
    //Shopping Order
    DbSet<Finance> Finances { get; set; }
    DbSet<Cost> Costs { get; set; }
    DbSet<ProductCostType> ProductCostTypes { get; set; }
    DbSet<Order> Orders { get; set; }
    DbSet<OrderDetaile> OrderDetailes { get; set; }



    int SaveChanges(bool acceptAllChangesOnSuccess);
    int SaveChanges();
    Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken());
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
}