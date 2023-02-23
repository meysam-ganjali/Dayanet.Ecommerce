using AutoMapper;
using Dayanet.Ecommerce.Application.Context;
using Dayanet.Ecommerce.Domain.Entities.Ecommerce;
using Dayanet.Ecommerce.SharedModels;
using Dayanet.Ecommerce.SharedModels.Dtos.Product.Create;
using Microsoft.EntityFrameworkCore;
using System.Net;
using Dayanet.Ecommerce.SharedModels.Dtos.CategoryAttribute;
using Dayanet.Ecommerce.SharedModels.Dtos.Product;
using Dayanet.Ecommerce.Comman.FileTools;
using Dayanet.Ecommerce.Domain.Entities.Common;
using Dayanet.Ecommerce.SharedModels.Dtos.Slider;
using System;
using Microsoft.AspNetCore.Hosting;

namespace Dayanet.Ecommerce.Application.Services.Repository.Product;

public class ProductRepository : IProductRepository {
    private readonly IDataBaseContext _db;
    private IMapper _mapper;
    private IHostingEnvironment _environment;

    public ProductRepository(IDataBaseContext db, IMapper mapper, IHostingEnvironment environment) {
        _db = db;
        _mapper = mapper;
        _environment = environment;
    }
    public async Task<ResultDto> AddToInventoryAsync(CreateInventoryDto inventoryDto) {
        var productInInventory = await _db.Inventories
            .Include(p => p.Product)
            .FirstOrDefaultAsync(x => x.ProductId == inventoryDto.ProductId);
        if (productInInventory == null) {
            var inventory = _mapper.Map<Inventory>(inventoryDto);
            await _db.Inventories.AddAsync(inventory);
            await _db.SaveChangesAsync();
            return new ResultDto {
                IsSuccess = true,
                Message = $"محصول با تعداد {inventory.ProductCount} در انبار با شناسه {inventory.SKU} ثبت گردید"
            };
        } else {
            productInInventory.ProductCount += inventoryDto.ProductCount;
            productInInventory.UpdateedDate = DateTime.Now;
            await _db.SaveChangesAsync();
            return new ResultDto {
                IsSuccess = true,
                Message = $" به محصول {productInInventory.Product.Name}  تعداد {inventoryDto.ProductCount} در انبار اضافه گردید"
            };
        }
    }

    public async Task<ResultDto<int>> AddAttribute(ProductAttributeDto attributeDto) {
        ProductAttribute productAttribute = new ProductAttribute {
            IsShow = attributeDto.IsShow,
            ProductId = attributeDto.ProductId,
            CategoryAttributeId = attributeDto.CategoryAttributeId
        };
        await _db.ProductAttributes.AddAsync(productAttribute);
        await _db.SaveChangesAsync();
        AttributeValue attributeValue = new AttributeValue {
            ColorHex = attributeDto.ColorHex,
            Value = attributeDto.Value,
            ProductAttributeId = productAttribute.Id
        };
        await _db.AttributeValues.AddAsync(attributeValue);
        await _db.SaveChangesAsync();
        return new ResultDto<int> {
            Data = productAttribute.ProductId,//Data: int = Product Id
            IsSuccess = true,
            Message = "مشخصه ثبت شد"
        };
    }

    public async Task<ResultDto<IEnumerable<CategoryAttributeDto>>> GetAttributeForProductCategory(int categoryId) {
        var attribute = await _db.CategoryAttributes
            .Include(x => x.Category)
            .ThenInclude(x => x.Products)
            .Where(x => x.CategoryId == categoryId).ToListAsync();
        if (attribute == null) {
            return new ResultDto<IEnumerable<CategoryAttributeDto>> {
                Data = null,
                IsSuccess = false,
                Message = "مشخصاتی یافت نشد"
            };
        }

        return new ResultDto<IEnumerable<CategoryAttributeDto>> {
            Data = attribute.Select(x => new CategoryAttributeDto {
                AttributeName = x.AttributeName,
                Id = x.Id
            }),
            IsSuccess = true,
        };
    }
    public async Task<ResultDto> AddProductGallaryAsync(CreateProductGallaryDto gallary) {

        UploadHelper uploadObj = new UploadHelper(_environment);
        List<ProductGallery> galleryLst = new List<ProductGallery>();
        foreach (var gallerys in gallary.Images) {
            var uploadedResult = uploadObj.UploadFile(gallerys, $@"assets\images\products\gallery\");
            galleryLst.Add(new ProductGallery() {
                ImagePath = uploadedResult.FileNameAddress,
                CreatedDate = DateTime.Now,
                IsShow = true,
                ProductId = gallary.ProductId,
            });
        }

        try {
            await _db.ProductGalleries.AddRangeAsync(galleryLst);
            await _db.SaveChangesAsync();
            return new ResultDto {
                IsSuccess = true,
                Message = "تصاویر به گالری محصول اضافه گردید"
            };
        } catch (Exception e) {
            return new ResultDto {
                IsSuccess = false,
                Message = e.Message
            };
        }

    }

    public async Task<ResultDto> RemoveFromGallery(int gallaryId) {
        var gallery = await _db.ProductGalleries
            .Include(x => x.Product)
            .FirstOrDefaultAsync(x => x.Id == gallaryId);
        if (gallery == null) {
            return new ResultDto {
                IsSuccess = false,
                Message = "گالری یافت نشد"
            };
        }

        string webRootPath = _environment.WebRootPath;
        var oldImagePath = Path.Combine(webRootPath, gallery.ImagePath.TrimStart('\\'));
        DeleteFile.DeleteFileFromRoot(oldImagePath);
        _db.ProductGalleries.Remove(gallery);
        await _db.SaveChangesAsync();
        return new ResultDto
        {
            IsSuccess = true,
            Message = $"تصویر از گالری محصول {gallery.Product.Name} حذف گردید"
        };
    }
}