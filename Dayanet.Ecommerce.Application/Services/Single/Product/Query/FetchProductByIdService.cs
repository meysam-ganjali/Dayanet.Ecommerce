using Dayanet.Ecommerce.Application.Context;
using Dayanet.Ecommerce.SharedModels;
using Dayanet.Ecommerce.SharedModels.Dtos.Product;
using Dayanet.Ecommerce.SharedModels.Dtos.Product.Get;
using Dayanet.Ecommerce.SharedModels.Dtos.ProductGallery;
using Microsoft.EntityFrameworkCore;

namespace Dayanet.Ecommerce.Application.Services.Single.Product.Query;

public class FetchProductByIdService : IFetchProductByIdService {
    private readonly IDataBaseContext _db;

    public FetchProductByIdService(IDataBaseContext db) {
        _db = db;
    }

    public async Task<ResultDto<ProductDetialeDto>> GetByIdAsync(int id) {
        var product = _db.Products
            .Include(p => p.Category)
            .ThenInclude(x => x.ParentCategory)
            .ThenInclude(x => x.CategoryAttributes)
            .Include(x => x.ProductAttributes)
            .ThenInclude(x => x.AttributeValues)
            .Include(x => x.ProductGalleries)
            .Include(x => x.Inventory)
            .Where(x => x.Id == id);
        if (product == null) {
            return new ResultDto<ProductDetialeDto> {
                Data = null,
                IsSuccess = false,
                Message = "محصول یافت نشد"
            };
        }

        var mappToDto = await product.Select(p => new ProductDetialeDto {
            Name = p.Name,
            Attributes = p.ProductAttributes.Select(attr => new productAttributeDtoForDetaile {
                CategoryAttributeName = attr.CategoryAttribute.AttributeName,
                AttributeValues = attr.AttributeValues.Select(attV => new AttributeValueDto {
                    Value = attV.Value,
                    ColorHex = attV.ColorHex,
                    CreatedDate = attV.CreatedDate,
                    IsShow = attV.IsShow,
                    Id = attV.Id,
                    ProductAttributeId = attV.ProductAttributeId,
                    UpdateedDate = attV.UpdateedDate,

                }).ToList(),
                Id = attr.Id,
                IsShow = attr.IsShow,
                CreatedDate = attr.CreatedDate,
                UpdateedDate = attr.UpdateedDate,
                CategoryAttributeId = attr.CategoryAttributeId,
                ProductId = p.Id
            }).ToList(),
            CategoryId = p.CategoryId,
            Price = p.Price,
            IsShow = p.IsShow,
            CreatedDate = p.CreatedDate,
            UpdateedDate = p.UpdateedDate,
            AllowCustomerComment = p.AllowCustomerComment,
            CategoryName = p.Category.Name,
            CreatedInventoryDate = p.Inventory.CreatedDate,
            FullDescription = p.FullDescription,
            Galleries = p.ProductGalleries.Select(g => new ProductGalleryDto {
                IsShow = g.IsShow,
                Id = g.Id,
                CreatedDate = g.CreatedDate,
                ProductId = g.ProductId,
                ImagePath = g.ImagePath,
                UpdateedDate = g.UpdateedDate,
            }).ToList(),
            Height = p.Height,
            Id = p.Id,
            IsSotialProduct = p.IsSotialProduct,
            Weight = p.Weight,
            ProductCount = p.Inventory.ProductCount,
            ImageCoverPath = p.ImageCoverPath,
            ShortDescription = p.ShortDescription,
            ShowCount = p.ShowCount,
            Rate = p.Rate,
            ShowOnHomepage = p.ShowOnHomepage,
            Length = p.Length,
            Width = p.Width,
            SKU = p.Inventory.SKU,
            LastSellDate = p.Inventory.LastSellDate,
            ParentName = p.Category.ParentCategory.Name,
            UpdateInventoryDate = p.Inventory.UpdateedDate
        }).FirstOrDefaultAsync();
        return new ResultDto<ProductDetialeDto> {
            IsSuccess = true,
            Data = mappToDto
        };
    }
}