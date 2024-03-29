﻿// <auto-generated />
using System;
using Dayanet.Ecommerce.DataLayer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Dayanet.Ecommerce.DataLayer.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20230215161536_InitCategoryerr")]
    partial class InitCategoryerr
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Dayanet.Ecommerce.Domain.Entities.Auth.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Dayanet.Ecommerce.Domain.Entities.Auth.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Dayanet.Ecommerce.Domain.Entities.Common.Banner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("PossitionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PossitionId");

                    b.ToTable("Banners");
                });

            modelBuilder.Entity("Dayanet.Ecommerce.Domain.Entities.Common.Possition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.HasKey("Id");

                    b.ToTable("Possitions");
                });

            modelBuilder.Entity("Dayanet.Ecommerce.Domain.Entities.Common.Slider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("PossitionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PossitionId");

                    b.ToTable("Sliders");
                });

            modelBuilder.Entity("Dayanet.Ecommerce.Domain.Entities.Ecommerce.AttributeValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ProductAttributeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductAttributeId");

                    b.ToTable("AttributeValues");
                });

            modelBuilder.Entity("Dayanet.Ecommerce.Domain.Entities.Ecommerce.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParentCategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParentCategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Dayanet.Ecommerce.Domain.Entities.Ecommerce.CategoryAttribute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("CategoryAttributes");
                });

            modelBuilder.Entity("Dayanet.Ecommerce.Domain.Entities.Ecommerce.Inventory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.ToTable("Inventories");
                });

            modelBuilder.Entity("Dayanet.Ecommerce.Domain.Entities.Ecommerce.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Dayanet.Ecommerce.Domain.Entities.Ecommerce.ProductAttribute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryAttributeId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryAttributeId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductAttributes");
                });

            modelBuilder.Entity("Dayanet.Ecommerce.Domain.Entities.Ecommerce.ProductGallery", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductGalleries");
                });

            modelBuilder.Entity("Dayanet.Ecommerce.Domain.Entities.ProductCommon.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Dayanet.Ecommerce.Domain.Entities.ProductCommon.Favorit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("Favorits");
                });

            modelBuilder.Entity("Dayanet.Ecommerce.Domain.Entities.ShoopingCart.Cart", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("Dayanet.Ecommerce.Domain.Entities.ShoopingCart.CartItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("CartId")
                        .HasColumnType("bigint");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("ProductId");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("Dayanet.Ecommerce.Domain.Entities.ShoppingOrder.Finance", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<int>("FinanceCosteId")
                        .HasColumnType("int");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("FinanceCosteId");

                    b.HasIndex("UserId");

                    b.ToTable("Finances");
                });

            modelBuilder.Entity("Dayanet.Ecommerce.Domain.Entities.ShoppingOrder.FinanceCost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.HasKey("Id");

                    b.ToTable("FinanceCosts");
                });

            modelBuilder.Entity("Dayanet.Ecommerce.Domain.Entities.ShoppingOrder.Order", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("FinanceId")
                        .HasColumnType("bigint");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("FinanceId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Dayanet.Ecommerce.Domain.Entities.ShoppingOrder.OrderDetaile", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("OrderId")
                        .HasColumnType("bigint");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetailes");
                });

            modelBuilder.Entity("Dayanet.Ecommerce.Domain.Entities.Auth.User", b =>
                {
                    b.HasOne("Dayanet.Ecommerce.Domain.Entities.Auth.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Dayanet.Ecommerce.Domain.Entities.Common.Banner", b =>
                {
                    b.HasOne("Dayanet.Ecommerce.Domain.Entities.Common.Possition", "Possition")
                        .WithMany("Banners")
                        .HasForeignKey("PossitionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Possition");
                });

            modelBuilder.Entity("Dayanet.Ecommerce.Domain.Entities.Common.Slider", b =>
                {
                    b.HasOne("Dayanet.Ecommerce.Domain.Entities.Common.Possition", "Possition")
                        .WithMany("Sliders")
                        .HasForeignKey("PossitionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Possition");
                });

            modelBuilder.Entity("Dayanet.Ecommerce.Domain.Entities.Ecommerce.AttributeValue", b =>
                {
                    b.HasOne("Dayanet.Ecommerce.Domain.Entities.Ecommerce.ProductAttribute", "ProductAttribute")
                        .WithMany("AttributeValues")
                        .HasForeignKey("ProductAttributeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ProductAttribute");
                });

            modelBuilder.Entity("Dayanet.Ecommerce.Domain.Entities.Ecommerce.Category", b =>
                {
                    b.HasOne("Dayanet.Ecommerce.Domain.Entities.Ecommerce.Category", "ParentCategory")
                        .WithMany("SubCategories")
                        .HasForeignKey("ParentCategoryId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("ParentCategory");
                });

            modelBuilder.Entity("Dayanet.Ecommerce.Domain.Entities.Ecommerce.CategoryAttribute", b =>
                {
                    b.HasOne("Dayanet.Ecommerce.Domain.Entities.Ecommerce.Category", "Category")
                        .WithMany("CategoryAttributes")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Dayanet.Ecommerce.Domain.Entities.Ecommerce.Inventory", b =>
                {
                    b.HasOne("Dayanet.Ecommerce.Domain.Entities.Ecommerce.Product", "Product")
                        .WithOne("Inventory")
                        .HasForeignKey("Dayanet.Ecommerce.Domain.Entities.Ecommerce.Inventory", "ProductId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Dayanet.Ecommerce.Domain.Entities.Ecommerce.Product", b =>
                {
                    b.HasOne("Dayanet.Ecommerce.Domain.Entities.Ecommerce.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Dayanet.Ecommerce.Domain.Entities.Ecommerce.ProductAttribute", b =>
                {
                    b.HasOne("Dayanet.Ecommerce.Domain.Entities.Ecommerce.CategoryAttribute", "CategoryAttribute")
                        .WithMany("ProductAttributes")
                        .HasForeignKey("CategoryAttributeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Dayanet.Ecommerce.Domain.Entities.Ecommerce.Product", "Product")
                        .WithMany("ProductAttributes")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CategoryAttribute");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Dayanet.Ecommerce.Domain.Entities.Ecommerce.ProductGallery", b =>
                {
                    b.HasOne("Dayanet.Ecommerce.Domain.Entities.Ecommerce.Product", "Product")
                        .WithMany("ProductGalleries")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Dayanet.Ecommerce.Domain.Entities.ProductCommon.Comment", b =>
                {
                    b.HasOne("Dayanet.Ecommerce.Domain.Entities.Ecommerce.Product", "Product")
                        .WithMany("Comments")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Dayanet.Ecommerce.Domain.Entities.Auth.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Dayanet.Ecommerce.Domain.Entities.ProductCommon.Favorit", b =>
                {
                    b.HasOne("Dayanet.Ecommerce.Domain.Entities.Ecommerce.Product", "Product")
                        .WithMany("Favorits")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Dayanet.Ecommerce.Domain.Entities.Auth.User", "User")
                        .WithMany("Favorits")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Dayanet.Ecommerce.Domain.Entities.ShoopingCart.Cart", b =>
                {
                    b.HasOne("Dayanet.Ecommerce.Domain.Entities.Auth.User", "User")
                        .WithMany("Carts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Dayanet.Ecommerce.Domain.Entities.ShoopingCart.CartItem", b =>
                {
                    b.HasOne("Dayanet.Ecommerce.Domain.Entities.ShoopingCart.Cart", "Cart")
                        .WithMany("CartItems")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Dayanet.Ecommerce.Domain.Entities.Ecommerce.Product", "Product")
                        .WithMany("CartItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Dayanet.Ecommerce.Domain.Entities.ShoppingOrder.Finance", b =>
                {
                    b.HasOne("Dayanet.Ecommerce.Domain.Entities.ShoppingOrder.FinanceCost", "FinanceCost")
                        .WithMany("Finances")
                        .HasForeignKey("FinanceCosteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Dayanet.Ecommerce.Domain.Entities.Auth.User", "User")
                        .WithMany("Finances")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("FinanceCost");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Dayanet.Ecommerce.Domain.Entities.ShoppingOrder.Order", b =>
                {
                    b.HasOne("Dayanet.Ecommerce.Domain.Entities.ShoppingOrder.Finance", "Finance")
                        .WithMany("Orders")
                        .HasForeignKey("FinanceId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Dayanet.Ecommerce.Domain.Entities.Auth.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Finance");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Dayanet.Ecommerce.Domain.Entities.ShoppingOrder.OrderDetaile", b =>
                {
                    b.HasOne("Dayanet.Ecommerce.Domain.Entities.ShoppingOrder.Order", "Order")
                        .WithMany("OrderDetailes")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Dayanet.Ecommerce.Domain.Entities.Ecommerce.Product", "Product")
                        .WithMany("OrderDetailes")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Dayanet.Ecommerce.Domain.Entities.Auth.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Dayanet.Ecommerce.Domain.Entities.Auth.User", b =>
                {
                    b.Navigation("Carts");

                    b.Navigation("Comments");

                    b.Navigation("Favorits");

                    b.Navigation("Finances");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Dayanet.Ecommerce.Domain.Entities.Common.Possition", b =>
                {
                    b.Navigation("Banners");

                    b.Navigation("Sliders");
                });

            modelBuilder.Entity("Dayanet.Ecommerce.Domain.Entities.Ecommerce.Category", b =>
                {
                    b.Navigation("CategoryAttributes");

                    b.Navigation("Products");

                    b.Navigation("SubCategories");
                });

            modelBuilder.Entity("Dayanet.Ecommerce.Domain.Entities.Ecommerce.CategoryAttribute", b =>
                {
                    b.Navigation("ProductAttributes");
                });

            modelBuilder.Entity("Dayanet.Ecommerce.Domain.Entities.Ecommerce.Product", b =>
                {
                    b.Navigation("CartItems");

                    b.Navigation("Comments");

                    b.Navigation("Favorits");

                    b.Navigation("Inventory")
                        .IsRequired();

                    b.Navigation("OrderDetailes");

                    b.Navigation("ProductAttributes");

                    b.Navigation("ProductGalleries");
                });

            modelBuilder.Entity("Dayanet.Ecommerce.Domain.Entities.Ecommerce.ProductAttribute", b =>
                {
                    b.Navigation("AttributeValues");
                });

            modelBuilder.Entity("Dayanet.Ecommerce.Domain.Entities.ShoopingCart.Cart", b =>
                {
                    b.Navigation("CartItems");
                });

            modelBuilder.Entity("Dayanet.Ecommerce.Domain.Entities.ShoppingOrder.Finance", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Dayanet.Ecommerce.Domain.Entities.ShoppingOrder.FinanceCost", b =>
                {
                    b.Navigation("Finances");
                });

            modelBuilder.Entity("Dayanet.Ecommerce.Domain.Entities.ShoppingOrder.Order", b =>
                {
                    b.Navigation("OrderDetailes");
                });
#pragma warning restore 612, 618
        }
    }
}
