﻿using Dayanet.Ecommerce.Application.Context;
using Dayanet.Ecommerce.Domain.Entities.Auth;
using Dayanet.Ecommerce.Domain.Entities.Common;
using Dayanet.Ecommerce.Domain.Entities.Ecommerce;
using Dayanet.Ecommerce.Domain.Entities.ProductCommon;
using Dayanet.Ecommerce.Domain.Entities.ShoopingCart;
using Dayanet.Ecommerce.Domain.Entities.ShoppingOrder;
using Microsoft.EntityFrameworkCore;

namespace Dayanet.Ecommerce.DataLayer.Context;

public class DataBaseContext : DbContext, IDataBaseContext {
    public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) {

    }
    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserAddress> UserAddresses { get; set; }
    public DbSet<Possition> Possitions { get; set; }
    public DbSet<Banner> Banners { get; set; }
    public DbSet<Slider> Sliders { get; set; }
    public DbSet<AttributeValue> AttributeValues { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<CategoryAttribute> CategoryAttributes { get; set; }
    public DbSet<Inventory> Inventories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductAttribute> ProductAttributes { get; set; }
    public DbSet<ProductGallery> ProductGalleries { get; set; }
    public DbSet<Favorit> Favorits { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<CartItem> CartItems { get; set; }
    public DbSet<Finance> Finances { get; set; }
    public DbSet<Cost> Costs { get; set; }
    public DbSet<ProductCostType> ProductCostTypes { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetaile> OrderDetailes { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<User>().HasIndex(x => x.CellPhone).IsUnique();
        modelBuilder.Entity<User>().HasIndex(x => x.Email).IsUnique();
        foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(s => s.GetForeignKeys())) {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }
        base.OnModelCreating(modelBuilder);
    }
}